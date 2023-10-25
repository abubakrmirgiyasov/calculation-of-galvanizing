using System;
using System.Collections.Generic;
using System.Linq;
using SZGC.Domain.Models;
using SZGC.Domain.ViewModels;

namespace SZGC.Api.Services
{
    public class OrderManager
    {
        public OrderViewModel FormingViewModel(Order order)
        {
            try
            {
                if (order != null)
                {
                    var nomenclaturesModels = new List<OrderNomenclatureViewModel>();

                    var nomenclatures = new List<OrderNomenclature>();

                    if (order.OrderNomenclatures != null)
                    {
                        nomenclatures = order.OrderNomenclatures.ToList();
                    }

                    for (int i = 0; i < nomenclatures.Count; i++)
                    {
                        nomenclaturesModels.Add(new OrderNomenclaturesManager().FormingViewModel(nomenclatures[i]));
                    }

                    return new OrderViewModel
                    {
                        Id = order.Id,
                        DateCreated = order.DateCreated,
                        Name = order.Name,
                        NumOfHitchStation = order.NumOfHitchStation,
                        CountTraverse = order.CountTraverse,
                        Time = order.Time,
                        OrderNomenclatures = nomenclaturesModels
                    };
                }
                else
                {
                    throw new Exception("Запись не найдено");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}