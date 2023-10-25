using System;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Windows.Forms;
using SZGC.Desktop.Views.Stage.Interfaces;

namespace SZGC.Desktop.Views.Stage
{
    public partial class AdvancedStageSearchView : Form, IAdvancedStageSearchView
    {
        private bool _cancel = true;

        public event Action Finish;

        public string StageName { get => Name_TB.Text; set => Name_TB.Text = value; }

        public DateTime TopDate { get; set; }

        public DateTime BottomDate { get; set; }

        public bool IsEnabled { get; set; }

        public bool Cancel { get => _cancel; set => _cancel = value; }

        public Form Form => this;

        public AdvancedStageSearchView()
        {
            InitializeComponent();
            IsEnabled = false;
        }

        private void Enable_CB_CheckedChanged(object sender, EventArgs e)
        {
            if (Enable_CB.Checked)
            {
                Top_DTP.Enabled = true;
                Bottom_DTP.Enabled = true;
                IsEnabled = true;
            }
            else
            {
                Top_DTP.Enabled = false;
                Bottom_DTP.Enabled = false;
                IsEnabled = false;
            }
        }

        private void Top_DTP_ValueChanged(object sender, EventArgs e)
        {
            TopDate = Enable_CB.Checked ? DateTime.Parse(Top_DTP.Value.ToShortDateString()) : new DateTime(2000, 1, 1);
        }

        private void Bottom_DTP_ValueChanged(object sender, EventArgs e)
        {
            BottomDate = Enable_CB.Checked ? DateTime.Parse(Bottom_DTP.Value.ToShortDateString()) : new DateTime(2000, 1, 1);
        }

        private void AdvancedStageSearchView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (_cancel)
                {
                    Finish?.Invoke();
                    e.Cancel = _cancel;
                }
            }
        }

        public void Info(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Warning(string message)
        {
            MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void Error(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
