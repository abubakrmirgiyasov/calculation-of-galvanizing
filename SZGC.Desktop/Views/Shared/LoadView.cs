using System.Windows.Forms;
using SZGC.Desktop.Views.Shared.Interfaces;

namespace SZGC.Desktop.Views.Shared
{
    public partial class LoadView : Form, ILoadView
    {
        public string Status { set => label1.Text = value; }

        public Form Form => this;

        public LoadView()
        {
            InitializeComponent();
        }
    }
}
