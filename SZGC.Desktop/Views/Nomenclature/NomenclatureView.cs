using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using SZGC.Desktop.Views.Nomenclature.Interfaces;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Views.Nomenclature
{
    public partial class NomenclatureView : Form, INomenclatureView
    {
        private bool _cancel = true;

        public event Action Start;
        public event Action Finish;
        public event Action AddStage;
        public event Action Delete;

        public Form Form => this;

        public string NomenclatureName { get => Name_TB.Text; set => Name_TB.Text = value; }

        public string Weight { get => Weight_TB.Text; set => Weight_TB.Text = value; }

        public string MaxCountTraverse { get => MaxCountTraverse_TB.Text; set => MaxCountTraverse_TB.Text = value; }

        public string MaxWeightTraverse { get => MaxWeightTraverse_TB.Text; set => MaxWeightTraverse_TB.Text = value; }

        public bool Cancel { get => _cancel; set => _cancel = value; }

        public NomenclatureStageViewModel ChoosedNomenclatureStage { get; set; }

        public NomenclatureView()
        {
            InitializeComponent();
        }

        private void NomenclatureView_Load(object sender, EventArgs e)
        {
            Stage_DGV.AutoGenerateColumns = false;
            Start?.Invoke();
        }

        public void ShowStages(List<NomenclatureStageViewModel> models)
        {
            Stage_DGV.DataSource = null;
            Stage_DGV.DataSource = new BindingList<NomenclatureStageViewModel>(models);
        }

        private void AddStage_B_Click(object sender, EventArgs e)
        {
            AddStage?.Invoke();
        }

        private void Weight_TB_Leave(object sender, EventArgs e)
        {
            Weight_TB.Text = Weight_TB.Text.Replace(".", ",");
        }

        private void MaxWeightTraverse_TB_Leave(object sender, EventArgs e)
        {
            MaxWeightTraverse_TB.Text = MaxWeightTraverse_TB.Text.Replace(".", ",");
        }

        private void Stage_DGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Error("Введите число");
        }

        private void Delete_B_Click(object sender, EventArgs e)
        {
            if (Stage_DGV.SelectedRows.Count == 1)
            {
                Delete?.Invoke();
            }
            else
            {
                Error("Вы не выбрали запись");
            }
        }

        private void Stage_DGV_SelectionChanged(object sender, EventArgs e)
        {
            if (Stage_DGV.CurrentCell.RowIndex >= 0 && Stage_DGV.SelectedRows.Count >= 1)
            {
                ChoosedNomenclatureStage = Stage_DGV.Rows[Stage_DGV.CurrentCell.RowIndex].DataBoundItem as NomenclatureStageViewModel;
            }
            else
            {
                ChoosedNomenclatureStage = null;
            }
        }

        private void NomenclatureView_FormClosing(object sender, FormClosingEventArgs e)
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
