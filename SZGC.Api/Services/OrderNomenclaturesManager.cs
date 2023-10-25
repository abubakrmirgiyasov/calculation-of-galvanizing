using System;
using System.Collections.Generic;
using System.Linq;
using SZGC.Domain.Models;
using SZGC.Domain.ViewModels;

namespace SZGC.Api.Services
{
    public class OrderNomenclaturesManager
    {
        public OrderNomenclatureViewModel FormingViewModel(OrderNomenclature orderNomenclature)
        {
            try
            {
                if (orderNomenclature != null)
                {
                    var nomenclaturesStageViewModels = new List<OrderNomenclatureStageViewModel>();

                    var nomenclaturesStages = new List<OrderNomenclatureStage>();

                    if (orderNomenclature.OrderNomenclatureStages != null)
                    {
                        nomenclaturesStages = orderNomenclature.OrderNomenclatureStages.ToList();
                    }

                    for (int i = 0; i < nomenclaturesStages.Count; i++)
                    {
                        nomenclaturesStageViewModels.Add(new OrderNomenclatureStageManager().FormingViewModel(nomenclaturesStages[i]));
                    }

                    return new OrderNomenclatureViewModel
                    {
                        Id = orderNomenclature.Id,
                        Count = orderNomenclature.Count,
                        AllWeight = orderNomenclature.AllWeight,
                        CountTraverse = orderNomenclature.CountTraverse,
                        Nomenclature = new NomenclatureManager().FormingViewModel(orderNomenclature.Nomenclature),
                        OrderNomenclatureStages = nomenclaturesStageViewModels,
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