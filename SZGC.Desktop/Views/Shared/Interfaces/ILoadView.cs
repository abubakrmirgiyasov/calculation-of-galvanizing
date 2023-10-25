using System;
using System.Windows.Forms;
using SZGC.Desktop.Common.Interfaces;

namespace SZGC.Desktop.Views.Shared.Interfaces
{
    public interface ILoadView : IView
    {
        string Status { set; }

        new DialogResult DialogResult { get; }
    }
}
