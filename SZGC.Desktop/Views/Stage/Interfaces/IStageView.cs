using System;
using SZGC.Desktop.Common.Interfaces;

namespace SZGC.Desktop.Views.Stage.Interfaces
{
    public interface IStageView : IView, IMessage
    {
        event Action Start;

        event Action Finish;

        string StageName { get; set; }

        string StageNum { get; set; }

        bool IsSumming { get; set; }

        bool Cancel { get; set; }
    }
}
