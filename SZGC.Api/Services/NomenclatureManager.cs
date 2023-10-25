using System;
using System.Collections.Generic;
using System.Linq;
using SZGC.Domain.Models;
using SZGC.Domain.ViewModels;

namespace SZGC.Api.Services
{
    public class NomenclatureManager
    {
        public NomenclatureViewModel FormingViewModel(Nomenclature nomenclature)
        {
            try
            {
                if (nomenclature != null)
                {
                    var models = new List<NomenclatureStageViewModel>();

                    var nomenclatureStages = new List<NomenclatureStage>();

                    if (nomenclature.NomenclatureStages != null)
                    {
                        nomenclatureStages = nomenclature.NomenclatureStages.ToList();
                    }

                    for (int i = 0; i < nomenclatureStages.Count; i++)
                    {
                        models.Add(new NomenclatureStageManager().FormingViewModel(nomenclatureStages[i]));
                    }

                    return new NomenclatureViewModel
                    {
                        Id = nomenclature.Id,
                        DateCreated = nomenclature.DateCreated,
                        MaxCountTraverse = nomenclature.MaxCountTraverse,
                        MaxWeightTraverse = nomenclature.MaxWeightTraverse,
                        Weight = nomenclature.Weight,
                        Name = nomenclature.Name,
                        NomenclatureStages = models,
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