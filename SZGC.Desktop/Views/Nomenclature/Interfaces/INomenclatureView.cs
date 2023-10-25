using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Views.Nomenclature.Interfaces
{
    public interface INomenclatureView : IView, IMessage
    {
        event Action Start;

        event Action Finish;

        event Action AddStage;

        event Action Delete;

        string NomenclatureName { get; set; }

        string Weight { get; set; }

        string MaxCountTraverse { get; set; }

        string MaxWeightTraverse { get; set; }

        bool Cancel { get; set; }

        NomenclatureStageViewModel ChoosedNomenclatureStage { get; set; }

        void ShowStages(List<NomenclatureStageViewModel> models);
    }
}
