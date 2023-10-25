using System;
using System.Windows.Forms;
using SZGC.Desktop.Views.Stage.Interfaces;

namespace SZGC.Desktop.Views.Stage
{
    public partial class StageView : Form, IStageView
    {
        private bool _cancel = true;

        public event Action Start;
        public event Action Finish;

        public Form Form => this;

        public string StageName { get => Name_TB.Text; set => Name_TB.Text = value; }

        public string StageNum { get => Num_NUD.Text; set => Num_NUD.Text = value; }

        public bool IsSumming { get => IsSumming_CB.Checked; set => IsSumming_CB.Checked = value; }

        public bool Cancel { get => _cancel; set => _cancel = value; }

        public StageView()
        {
            InitializeComponent();
        }

        private void StageView_Load(object sender, EventArgs e)
        {
            Start?.Invoke();
        }

        private void StageView_FormClosing(object sender, FormClosingEventArgs e)
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
