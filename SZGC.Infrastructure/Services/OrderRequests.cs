using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.Models;
using SZGC.Infrastructure.Data;

namespace SZGC.Infrastructure.Services
{
    public class OrderRequests
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public async Task<List<Order>> GetOrders()
        {
            try
            {
                var list = await _context.Orders
                    .Include(p => p.OrderNomenclatures)
                    .ThenInclude(p => p.OrderNomenclatureStages)
                    .ThenInclude(p => p.Stage)
                    .Include(p => p.OrderNomenclatures)
                    .ThenInclude(p => p.Nomenclature)
                    .ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Order> GetOrderById(Guid id)
        {
            try
            {
                var order = await _context.Orders
                    .Include(p => p.OrderNomenclatures)
                    .ThenInclude(p => p.OrderNomenclatureStages)
                    .ThenInclude(p => p.Stage)
                    .Include(p => p.OrderNomenclatures)
                    .ThenInclude(p => p.Nomenclature)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (order == null)
                {
                    throw new Exception("Заказ с таким ID не существует");
                }

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task AddOrder(OrderBindingModel order, User user)
        {
            try
            {
                var current = await _context.Orders.AddAsync(new Order
                {
                    CountTraverse = order.OrderNomenclatures.Sum(p => p.CountTraverse),
                    Name = order.Name,
                    NumOfHitchStation = order.NumOfHitchStation,
                    DateCreated = DateTime.Now,
                    Time = order.Time,
                    UserId = user.Id,
                });

                await _context.SaveChangesAsync();

                for (int i = 0; i < order.OrderNomenclatures.Count; i++)
                {
                    var currentNomenclature = await _context.OrderNomenclatures.AddAsync(new OrderNomenclature
                    {
                        OrderId = current.Entity.Id,
                        Count = order.OrderNomenclatures[i].Count,
                        CountTraverse = order.OrderNomenclatures[i].CountTraverse,
                        AllWeight = order.OrderNomenclatures[i].AllWeight,
                        NomenclatureId = order.OrderNomenclatures[i].NomenclatureId
                    });

                    await _context.SaveChangesAsync();

                    for (int j = 0; j < order.OrderNomenclatures[i].OrderNomenclatureStages.Count; j++)
                    {
                        await _context.OrderNomenclatureStages.AddAsync(new OrderNomenclatureStage
                        {
                            OrderNomenclatureId = currentNomenclature.Entity.Id,
                            Time = order.OrderNomenclatures[i].OrderNomenclatureStages[j].Time,
                            StageId = order.OrderNomenclatures[i].OrderNomenclatureStages[j].StageId,
                        });

                        await _context.SaveChangesAsync();
                    }
                }

                current.Entity.Time = await CountTime(order);

                _context.Update(current.Entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task EditOrder(OrderBindingModel orderModel)
        {
            try
            {
                var order = await GetOrderById(orderModel.Id);

                order.Name = orderModel.Name;
                order.CountTraverse = orderModel.OrderNomenclatures.Sum(p => p.CountTraverse);
                order.NumOfHitchStation = orderModel.NumOfHitchStation;

                order.OrderNomenclatures.Clear();

                for (int i = 0; i < orderModel.OrderNomenclatures.Count; i++)
                {
                    var currentNomenclature = new OrderNomenclature
                    {
                        Count = orderModel.OrderNomenclatures[i].Count,
                        NomenclatureId = orderModel.OrderNomenclatures[i].NomenclatureId,
                        CountTraverse = orderModel.OrderNomenclatures[i].CountTraverse,
                        AllWeight = orderModel.OrderNomenclatures[i].AllWeight,
                        OrderNomenclatureStages = new List<OrderNomenclatureStage>()
                    };

                    await _context.SaveChangesAsync();

                    for (int j = 0; j < orderModel.OrderNomenclatures[i].OrderNomenclatureStages.Count; j++)
                    {
                        currentNomenclature.OrderNomenclatureStages.Add(new OrderNomenclatureStage
                        {
                            Time = orderModel.OrderNomenclatures[i].OrderNomenclatureStages[j].Time,
                            StageId = orderModel.OrderNomenclatures[i].OrderNomenclatureStages[j].StageId,
                        });

                        await _context.SaveChangesAsync();
                    }

                    order.OrderNomenclatures.Add(currentNomenclature);
                }

                order.Time = await CountTime(orderModel);

                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task RemoveOrder(OrderBindingModel orderModel)
        {
            try
            {
                var order = await GetOrderById(orderModel.Id);
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        private async Task<int> CountTime(OrderBindingModel order)
        {
            int totalTime = 0;

            for (int i = 0; i < order.OrderNomenclatures.Count; i++)
            {
                Nomenclature nomenclature = await new NomenclatureRequests().GetNomenclatureById(order.OrderNomenclatures[i].NomenclatureId);

                int traverseRunParallel = 1;

                if (order.OrderNomenclatures[i].CountTraverse % order.NumOfHitchStation > 0)
                {
                    traverseRunParallel = order.OrderNomenclatures[i].CountTraverse / order.NumOfHitchStation + 1;
                }
                else
                {
                    traverseRunParallel = order.OrderNomenclatures[i].CountTraverse / order.NumOfHitchStation;
                }

                int time = 0;

                var stagesReplace = order.OrderNomenclatures[i].OrderNomenclatureStages.FindAll(p => new StageRequests().GetStageById(p.StageId).IsSumming);

                for (int j = 0; j < stagesReplace.Count; j++)
                {
                    time += stagesReplace[j].Time;
                }

                totalTime += time * traverseRunParallel;

                time = 0;
                var stagesWithoutReplace = order.OrderNomenclatures[i].OrderNomenclatureStages.FindAll(p => !new StageRequests().GetStageById(p.StageId).IsSumming);

                for (int j = 0; j < stagesWithoutReplace.Count; j++)
                {
                    time += stagesWithoutReplace[j].Time;
                }

                totalTime += time;
            }

            return totalTime;
        }
    }
}
