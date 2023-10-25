using System;
using System.Windows.Forms;
using SZGC.Desktop.Views.Nomenclature.Interfaces;

namespace SZGC.Desktop.Views.Nomenclature
{
    public partial class AdvancedNomenclatureSearchView : Form, IAdvancedNomenclatureSearchView
    {
        private bool _cancel = true;

        public event Action Finish;

        public string NomenclatureName { get => Name_TB.Text; set => Name_TB.Text = value; }

        public bool IsEnabled { get; set; }

        public string Weight { get => Weight_TB.Text; set => Weight_TB.Text = value; }

        public string MaxCountTraverse { get => MaxCount_TB.Text; set => MaxCount_TB.Text = value; }

        public string MaxWeightTraverse { get => MaxWeight_TB.Text; set => MaxWeight_TB.Text = value; }

        public bool Cancel { get => _cancel; set => _cancel = value; }

        public Form Form => this;

        public DateTime TopDate { get; set; }

        public DateTime BottomDate { get; set; }

        public AdvancedNomenclatureSearchView()
        {
            InitializeComponent();
            IsEnabled = false;
        }

        private void EnableDate_CB_CheckedChanged(object sender, EventArgs e)
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

        private void AdvancedNomenclatureSearchView_FormClosing(object sender, FormClosingEventArgs e)
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
