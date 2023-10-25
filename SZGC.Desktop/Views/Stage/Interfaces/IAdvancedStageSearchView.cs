
using System;
using SZGC.Desktop.Common.Interfaces;

namespace SZGC.Desktop.Views.Stage.Interfaces
{
    public interface IAdvancedStageSearchView : IView, IMessage
    {
        event Action Finish;

        string StageName { get; set; }

        DateTime TopDate { get; set; }

        DateTime BottomDate { get; set; }

        bool IsEnabled { get; set; }

        bool Cancel { get; set; }
    }
}
