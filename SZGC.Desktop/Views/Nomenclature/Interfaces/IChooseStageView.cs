using System;
using System.Collections.Generic;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Views.Nomenclature.Interfaces
{
    public interface IChooseStageView : IView, IMessage
    {
        event Action Start;

        event Action Finish;

        StageViewModel Choosed { get; set; }

        bool Cancel { get; set; }

        void ShowStages(List<StageViewModel> stages);
    }
}
