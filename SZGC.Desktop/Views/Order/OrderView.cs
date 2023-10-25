using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using SZGC.Desktop.Views.Order.Interfaces;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Views.Order
{
    public partial class OrderView : Form, IOrderView
    {
        private bool _cancel = true;

        public event Action Start;
        public event Action Finish;
        public event Action NomenclatureAdd;
        public event Action NomenclatureDelete;
        public event Action ShowChoosesStages;
        public event Action StageAdd;
        public event Action StageDelete;

        public string OrderName { get => Name_TB.Text; set => Name_TB.Text = value; }

        public string NumOfHitchStation { get => NumOfHitchStation_NUD.Text; set => NumOfHitchStation_NUD.Text = value; }

        public bool Cancel { get => _cancel; set => _cancel = value; }

        public OrderNomenclatureViewModel ChoosedNomenclature { get; set; }

        public OrderNomenclatureStageViewModel ChoosedNomenclatureStage { get; set; }

        public Form Form => this;

        public OrderView()
        {
            InitializeComponent();
        }

        private void OrderView_Load(object sender, EventArgs e)
        {
            Nomenclature_DGV.AutoGenerateColumns = false;
            Stage_DGV.AutoGenerateColumns = false;

            Start?.Invoke();
        }

        private void NomenclatureAdd_B_Click(object sender, EventArgs e)
        {
            NomenclatureAdd?.Invoke();
        }

        private void NomenclatureDelete_B_Click(object sender, EventArgs e)
        {
            NomenclatureDelete?.Invoke();
        }

        private void StageAdd_B_Click(object sender, EventArgs e)
        {
            StageAdd?.Invoke();
        }

        private void StageDelete_B_Click(object sender, EventArgs e)
        {
            StageDelete?.Invoke();
        }

        private void Nomenclature_DGV_SelectionChanged(object sender, EventArgs e)
        {
            if (Nomenclature_DGV.CurrentCell.RowIndex >= 0 && Nomenclature_DGV.SelectedRows.Count >= 1)
            {
                ChoosedNomenclature = Nomenclature_DGV.Rows[Nomenclature_DGV.CurrentCell.RowIndex].DataBoundItem as OrderNomenclatureViewModel;
                StageAdd_B.Enabled = true;
            }
            else
            {
                ChoosedNomenclature = null;
                StageAdd_B.Enabled = false;
            }

            ShowChoosesStages?.Invoke();
        }

        private void Stage_DGV_SelectionChanged(object sender, EventArgs e)
        {
            if (Stage_DGV.CurrentCell.RowIndex >= 0 && Stage_DGV.SelectedRows.Count >= 1)
            {
                ChoosedNomenclatureStage = Stage_DGV.Rows[Stage_DGV.CurrentCell.RowIndex].DataBoundItem as OrderNomenclatureStageViewModel;
                StageDelete_B.Enabled = true;
            }
            else
            {
                ChoosedNomenclatureStage = null;
                StageDelete_B.Enabled = false;
            }
        }

        public void ShowStages(List<OrderNomenclatureStageViewModel> models)
        {
            Stage_DGV.DataSource = null;
            Stage_DGV.DataSource = new BindingList<OrderNomenclatureStageViewModel>(models);
        }

        public void ShowNomenclatures(List<OrderNomenclatureViewModel> models)
        {
            Nomenclature_DGV.DataSource = null;
            Nomenclature_DGV.DataSource = new BindingList<OrderNomenclatureViewModel>(models);
        }

        private void Nomenclature_DGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.RowIndex >= 0 && Nomenclature_DGV.EditingControl.Text.IndexOf('.') != -1)
            {
                Nomenclature_DGV.EditingControl.Text = Nomenclature_DGV.EditingControl.Text.Replace(".", ",");
                Nomenclature_DGV.EndEdit();
            }
            else
            {
                Error("Введите число");
            }
        }

        private void Stage_DGV_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Error("Введите число");
        }

        private void Nomenclature_DGV_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = Nomenclature_DGV[e.ColumnIndex, e.RowIndex].ColumnIndex;

            if (columnIndex == 1)
            {
                Nomenclature_DGV[2, e.RowIndex].Value =
                   Math.Round(double.Parse(Nomenclature_DGV[1, e.RowIndex].Value.ToString()) * ChoosedNomenclature.Nomenclature.Weight, 2);
            }
            else if (columnIndex == 2)
            {
                Nomenclature_DGV[2, e.RowIndex].Value = Nomenclature_DGV[2, e.RowIndex].Value.ToString().Replace(".", ",");

                if (double.Parse(Nomenclature_DGV[2, e.RowIndex].Value.ToString()) % ChoosedNomenclature.Nomenclature.Weight > 0)
                {
                    Nomenclature_DGV[1, e.RowIndex].Value =
                        Math.Truncate(double.Parse(Nomenclature_DGV[2, e.RowIndex].Value.ToString()) / ChoosedNomenclature.Nomenclature.Weight) + 1;
                }
                else
                {
                    Nomenclature_DGV[1, e.RowIndex].Value =
                        double.Parse(Nomenclature_DGV[2, e.RowIndex].Value.ToString()) / ChoosedNomenclature.Nomenclature.Weight;
                }

                Nomenclature_DGV[2, e.RowIndex].Value = Math.Round(double.Parse(Nomenclature_DGV[2, e.RowIndex].Value.ToString()), 2);
            }

            OrderNomenclatureViewModel changing = Nomenclature_DGV.SelectedRows[0].DataBoundItem as OrderNomenclatureViewModel;

            if ((int.Parse(Nomenclature_DGV[1, e.RowIndex].Value.ToString()) % changing.Nomenclature.MaxCountTraverse) > 0)
            {
                Nomenclature_DGV[3, e.RowIndex].Value = int.Parse(Nomenclature_DGV[1, e.RowIndex].Value.ToString()) / changing.Nomenclature.MaxCountTraverse + 1;
            }
            else
            {
                Nomenclature_DGV[3, e.RowIndex].Value = int.Parse(Nomenclature_DGV[1, e.RowIndex].Value.ToString()) / changing.Nomenclature.MaxCountTraverse;
            }
        }

        private void OrderView_FormClosing(object sender, FormClosingEventArgs e)
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
