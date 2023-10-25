using System;
using System.Collections.Generic;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Views.Order.Interfaces
{
    public interface IOrderView : IView, IMessage
    {
        event Action Start;

        event Action Finish;

        event Action NomenclatureAdd;

        event Action NomenclatureDelete;

        event Action ShowChoosesStages;

        event Action StageAdd;

        event Action StageDelete;

        string OrderName { get; set; }

        string NumOfHitchStation { get; set; }

        OrderNomenclatureViewModel ChoosedNomenclature { get; set; }
        OrderNomenclatureStageViewModel ChoosedNomenclatureStage { get; set; }

        bool Cancel { get; set; }

        void ShowStages(List<OrderNomenclatureStageViewModel> models);

        void ShowNomenclatures(List<OrderNomenclatureViewModel> models);
    }
}
