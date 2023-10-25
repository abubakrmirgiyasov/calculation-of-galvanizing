using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SZGC.Desktop.Views.Nomenclature.Interfaces;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Views.Nomenclature
{
    public partial class ChooseStageView : Form, IChooseStageView
    {
        private bool _cancel = true;

        public event Action Start;
        public event Action Finish;

        public bool Cancel { get => _cancel; set => _cancel = value; }

        public Form Form => this;

        public StageViewModel Choosed
        {
            get => Stages_LB.SelectedItem != null ?
                Stages_LB.SelectedItem as StageViewModel :
                throw new Exception("Не выбран этап");
            set => Stages_LB.SelectedItem = value;
        }

        public ChooseStageView()
        {
            InitializeComponent();
        }

        private void ChooseView_Load(object sender, EventArgs e)
        {
            Start?.Invoke();
        }

        private void ChooseView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Finish?.Invoke();
        }

        public void ShowStages(List<StageViewModel> stages)
        {
            Stages_LB.DataSource = stages;
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
