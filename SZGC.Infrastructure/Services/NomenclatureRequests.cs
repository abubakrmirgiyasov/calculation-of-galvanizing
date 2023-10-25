using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SZGC.Domain.BindingModels;
using SZGC.Domain.Models;
using SZGC.Infrastructure.Data;

namespace SZGC.Infrastructure.Services
{
    public class NomenclatureRequests
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public async Task<List<Nomenclature>> GetNomenclatures()
        {
            try
            {
                var list = await _context.Nomenclatures
                    .Include(x => x.NomenclatureStages)
                    .ThenInclude(x => x.Stage)
                    .ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Nomenclature> GetNomenclatureById(Guid id)
        {
            try
            {
                var nomenclature = await _context.Nomenclatures
                    .Include(x => x.OrderNomenclatures)
                    .Include(x => x.NomenclatureStages)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (nomenclature == null)
                {
                    throw new Exception("Номенклатура с таким ID не существует");
                }

                return nomenclature;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task AddNomenclature(NomenclatureBindingModel nomenclatureModel, User user)
        {
            try
            {
                var current = await _context.Nomenclatures.AddAsync(new Nomenclature
                {
                    DateCreated = DateTime.Now,
                    Name = nomenclatureModel.Name,
                    Weight = nomenclatureModel.Weight,
                    MaxCountTraverse = nomenclatureModel.MaxCountTraverse,
                    MaxWeightTraverse = nomenclatureModel.MaxWeightTraverse,
                    UserId = user.Id,
                });
                await _context.SaveChangesAsync();

                for (int i = 0; i < nomenclatureModel.NomenclatureStages.Count; i++)
                {
                    await _context.NomenclatureStages.AddAsync(new NomenclatureStage
                    {
                        NomenclatureId = current.Entity.Id,
                        StageId = nomenclatureModel.NomenclatureStages[i].StageId,
                        Time = nomenclatureModel.NomenclatureStages[i].Time,
                    });

                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task EditNomenclature(NomenclatureBindingModel nomenclatureModel)
        {
            try
            {
                var nomenclature = await GetNomenclatureById(nomenclatureModel.Id);

                nomenclature.Name = nomenclatureModel.Name;
                nomenclature.MaxCountTraverse = nomenclatureModel.MaxCountTraverse;
                nomenclature.MaxWeightTraverse = nomenclatureModel.MaxWeightTraverse;
                nomenclature.Weight = nomenclatureModel.Weight;
                nomenclature.NomenclatureStages.Clear();

                for (int i = 0; i < nomenclatureModel.NomenclatureStages.Count; i++)
                {
                    nomenclature.NomenclatureStages.Add(new NomenclatureStage
                    {
                        NomenclatureId = nomenclature.Id,
                        StageId = nomenclatureModel.NomenclatureStages[i].StageId,
                        Time = nomenclatureModel.NomenclatureStages[i].Time
                    });

                    await _context.SaveChangesAsync();
                }

                _context.Nomenclatures.Update(nomenclature);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task RemoveNomenclature(NomenclatureBindingModel nomenclatureModel)
        {
            try
            {
                var nomenclature = await GetNomenclatureById(nomenclatureModel.Id);
                _context.Nomenclatures.Remove(nomenclature);
                await _context.SaveChangesAsync();
            }
            catch (InvalidOperationException ex)
            {
                throw new DbUpdateConcurrencyException("Некоторые заказы связаны с этой номенклатурой, сначала удалите заказы", ex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}

