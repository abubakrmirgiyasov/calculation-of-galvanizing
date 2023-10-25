using System;
using SZGC.Domain.Models;
using SZGC.Domain.ViewModels;

namespace SZGC.Api.Services
{
    public class NomenclatureStageManager
    {
        public NomenclatureStageViewModel FormingViewModel(NomenclatureStage nomenclatureStage)
        {
            try
            {
                if (nomenclatureStage != null)
                {
                    return new NomenclatureStageViewModel
                    {
                        Id = nomenclatureStage.Id,
                        Stage = new StageManager().FormingViewModel(nomenclatureStage.Stage),
                        Time = nomenclatureStage.Time,
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