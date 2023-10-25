using System;
using System.Collections.Generic;
using SZGC.Desktop.Services.Interfaces;
using SZGC.Domain.BindingModels;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Services.Managers
{
    public class NomenclatureManagerService : INomenclatureManagerService
    {
        public NomenclatureBindingModel FormingBindingModel(NomenclatureViewModel nomenclatureModel)
        {
			try
			{
                if (nomenclatureModel != null)
                {
                    var models = new List<NomenclatureStageBindingModel>();

                    for (int i = 0; i < nomenclatureModel.NomenclatureStages.Count; i++)
                    {
                        models.Add(new NomenclatureStageBindingModel
                        {
                            Id = nomenclatureModel.NomenclatureStages[i].Id,
                            Time = nomenclatureModel.NomenclatureStages[i].Time,
                            StageId = nomenclatureModel.NomenclatureStages[i].Stage.Id,
                        });
                    }

                    return new NomenclatureBindingModel
                    {
                        Id = nomenclatureModel.Id,
                        Name = nomenclatureModel.Name,
                        Weight = nomenclatureModel.Weight,
                        MaxWeightTraverse = nomenclatureModel.MaxWeightTraverse,
                        MaxCountTraverse = nomenclatureModel.MaxCountTraverse,
                        NomenclatureStages = models,
                    };
                }
                else
                {
                    throw new Exception("Пустая номенклатура");
                }
            }
			catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
			}
        }
    }
}
