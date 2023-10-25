using System;
using System.Collections.Generic;
using SZGC.Desktop.Common.Interfaces;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Views.Order.Interfaces
{
    public interface IChooseNomenclatureView : IView, IMessage
    {
        event Action Start;

        event Action Finish;

        NomenclatureViewModel Choosed { get; set; }

        bool Cancel { get; set; }

        void ShowNomenclatures(List<NomenclatureViewModel> nomenclatures);
    }
}
