using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SZGC.Desktop.Common.Interfaces;

namespace SZGC.Desktop.Views.Setting.Interfaces
{
    public interface ISettingView : IView, IMessage
    {
        event Action Start;

        event Action Save;

        string WorkingShift { get; set; }
    }
}
