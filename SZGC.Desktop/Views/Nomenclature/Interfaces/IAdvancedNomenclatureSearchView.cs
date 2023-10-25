using System;
using SZGC.Desktop.Common.Interfaces;

namespace SZGC.Desktop.Views.Nomenclature.Interfaces
{
    public interface IAdvancedNomenclatureSearchView : IView, IMessage
    {
        event Action Finish;

        string NomenclatureName { get; set; }

        DateTime TopDate { get; set; }

        DateTime BottomDate { get; set; }

        bool IsEnabled { get; set; }

        string Weight { get; set; }

        string MaxCountTraverse { get; set; }

        string MaxWeightTraverse { get; set; }

        bool Cancel { get; set; }
    }
}
