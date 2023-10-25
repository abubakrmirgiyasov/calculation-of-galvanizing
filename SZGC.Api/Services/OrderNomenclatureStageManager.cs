using System;
using SZGC.Domain.Models;
using SZGC.Domain.ViewModels;

namespace SZGC.Api.Services
{
    public class OrderNomenclatureStageManager
    {
        public OrderNomenclatureStageViewModel FormingViewModel(OrderNomenclatureStage orderNomenclatureStage)
        {
            try
            {
                if (orderNomenclatureStage != null)
                {
                    return new OrderNomenclatureStageViewModel
                    {
                        Id = orderNomenclatureStage.Id,
                        Stage = new StageManager().FormingViewModel(orderNomenclatureStage.Stage),
                        Time = orderNomenclatureStage.Time
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