using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using SZGC.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SZGC.Domain.BindingModels;
using SZGC.Domain.Models;
using System.Linq;

namespace SZGC.Infrastructure.Services
{
    public class StageRequests
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public async Task<List<Stage>> GetStages()
        {
            try
            {
                var list = await _context.Stages
                    .OrderBy(x => x.SortedBy)
                    .ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Stage> GetStageByIdAsync(Guid id)
        {
            try
            {
                var stage = await _context.Stages
                    .Include(x => x.User)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (stage == null)
                {
                    throw new Exception("Этап с таким ID не существует");
                }

                return stage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Stage GetStageById(Guid id)
        {
            try
            {
                var stage = _context.Stages
                    .Include(x => x.User)
                    .FirstOrDefault(x => x.Id == id);

                if (stage == null)
                {
                    throw new Exception("Этап с таким ID не существует");
                }

                return stage;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task AddStage(StageBindingModel stage, User user)
        {
            try
            {
                await _context.Stages.AddAsync(new Stage
                {
                    DateCreated = DateTime.Now,
                    Name = stage.Name,
                    SortedBy = stage.SortedBy,
                    IsSumming = stage.IsSumming,
                    UserId = user.Id
                });
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task EditStage(StageBindingModel stageModel)
        {
            try
            {
                var stage = await GetStageByIdAsync(stageModel.Id);

                stage.Name = stageModel.Name;
                stage.SortedBy = stageModel.SortedBy;
                stage.IsSumming = stageModel.IsSumming;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task RemoveStage(StageBindingModel stageModel)
        {
            try
            {
                var stage = await GetStageByIdAsync(stageModel.Id);
                _context.Stages.Remove(stage);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateConcurrencyException("Некоторые заказы и номенклатуры связаны с этим этапом, сначала удалите номенклатуры и заказы", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
