using System.Windows.Forms;

namespace SZGC.Desktop.Common.Interfaces
{
    public interface IView
    {
        void Show();

        void Close();

        void Hide();

        FormWindowState WindowState { get; set; }

        bool ShowInTaskbar { get; set; }

        DialogResult ShowDialog();

        DialogResult DialogResult { get; set; }

        Form Owner { get; set; }

        Form Form { get; }

        bool IsDisposed { get; }
    }
}
