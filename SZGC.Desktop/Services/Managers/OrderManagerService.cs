using System;
using System.Collections.Generic;
using SZGC.Desktop.Services.Interfaces;
using SZGC.Domain.BindingModels;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Services.Managers
{
    public class OrderManagerService : IOrderManagerService
    {
        public OrderBindingModel FormingBindingModel(OrderViewModel orderModel)
        {
            try
            {
                if (orderModel != null)
                {
                    var nomenclatureModels = new List<OrderNomenclatureBindingModel>();

                    for (int i = 0; i < orderModel.OrderNomenclatures.Count; i++)
                    {
                        var nomeclatureStageModels = new List<OrderNomenclatureStageBindingModel>();

                        for (int j = 0; j < orderModel.OrderNomenclatures[i].OrderNomenclatureStages.Count; j++)
                        {
                            nomeclatureStageModels.Add(new OrderNomenclatureStageBindingModel
                            {
                                Id = orderModel.OrderNomenclatures[i].OrderNomenclatureStages[j].Id,
                                StageId = orderModel.OrderNomenclatures[i].OrderNomenclatureStages[j].Stage.Id,
                                Time = orderModel.OrderNomenclatures[i].OrderNomenclatureStages[j].Time
                            });
                        }

                        nomenclatureModels.Add(new OrderNomenclatureBindingModel
                        {
                            Id = orderModel.OrderNomenclatures[i].Id,
                            Count = orderModel.OrderNomenclatures[i].Count,
                            AllWeight = (int)orderModel.OrderNomenclatures[i].AllWeight,
                            CountTraverse = orderModel.OrderNomenclatures[i].CountTraverse,
                            NomenclatureId = orderModel.OrderNomenclatures[i].Nomenclature.Id,
                            OrderNomenclatureStages = nomeclatureStageModels
                        });
                    }

                    return new OrderBindingModel
                    {
                        Id = orderModel.Id,
                        Name = orderModel.Name,
                        NumOfHitchStation = orderModel.NumOfHitchStation,
                        CountTraverse = orderModel.CountTraverse,
                        Time = orderModel.Time,
                        OrderNomenclatures = nomenclatureModels
                    };
                }
                else
                {
                    throw new Exception("Пустой заказ");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
