using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SZGC.Desktop.Views.Order.Interfaces;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Views.Order
{
    public partial class ChooseNomenclatureView : Form, IChooseNomenclatureView
    {
        private bool _cancel = true;
        private List<NomenclatureViewModel> _nomenclatures = new List<NomenclatureViewModel>();


        public event Action Start;
        public event Action Finish;

        public bool Cancel { get => _cancel; set => _cancel = value; }

        public Form Form => this;

        public NomenclatureViewModel Choosed
        {
            get => Nomenclatures_LB.SelectedItem != null ?
                Nomenclatures_LB.SelectedItem as NomenclatureViewModel :
                throw new Exception("Не выбрана номенклатура");
            set => Nomenclatures_LB.SelectedItem = value;
        }

        public ChooseNomenclatureView()
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

        public void ShowNomenclatures(List<NomenclatureViewModel> nomenclatures)
        {
            Nomenclatures_LB.DataSource = null;
            Nomenclatures_LB.DataSource = nomenclatures;

            foreach (var item in nomenclatures)
            {
                _nomenclatures.Add(item);
            }
        }

        private void Search_TB_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Search_TB.Text))
            {
                Nomenclatures_LB.DataSource = null;
                Nomenclatures_LB.Items.Clear();

                foreach (var item in _nomenclatures)
                {
                    if (item.Name.IndexOf(Search_TB.Text) != -1)
                    {
                        Nomenclatures_LB.Items.Add(item);
                    }
                }
            }
            else if (Search_TB.Text == "")
            {
                Nomenclatures_LB.Items.Clear();

                foreach (var item in _nomenclatures)
                {
                    Nomenclatures_LB.Items.Add(item);
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
