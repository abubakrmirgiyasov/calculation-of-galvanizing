using System.Windows.Forms;

namespace SZGC.Desktop.Views.Main
{
    public class Column : DataGridViewColumn
    {
        public void CreateOrderColumns(DataGridView dataGrid)
        {
            DataGridViewColumn[] orders = new DataGridViewTextBoxColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = DataGridOrderConstants.Id,
                    HeaderText = DataGridOrderConstants.IdHeaderText,
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = DataGridOrderConstants.Name,
                    HeaderText = DataGridOrderConstants.NameHeaderText,
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = DataGridOrderConstants.NumOfHitchStation,
                    HeaderText = DataGridOrderConstants.NumOfHitchStationHeader,
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = DataGridOrderConstants.CountTraverse,
                    HeaderText = DataGridOrderConstants.CountTraverseHeaderText,
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = DataGridOrderConstants.Time,
                    HeaderText = DataGridOrderConstants.TimeHeaderText,
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = DataGridOrderConstants.Date,
                    HeaderText = DataGridOrderConstants.DateHeaderText,
                },
            };

            dataGrid.Columns.AddRange(orders);
        }

        public void CreateNomenclatureColumns(DataGridView dataGrid)
        {
            DataGridViewColumn[] nomenclatures = new DataGridViewTextBoxColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = DataGridNomenclatureConstants.Id,
                    HeaderText = DataGridNomenclatureConstants.IdHeaderText,
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = DataGridNomenclatureConstants.Name,
                    HeaderText = DataGridNomenclatureConstants.NameHeaderText,
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = DataGridNomenclatureConstants.Date,
                    HeaderText = DataGridNomenclatureConstants.DateHeaderText,
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = DataGridNomenclatureConstants.Weight,
                    HeaderText = DataGridNomenclatureConstants.WeightHeaderText,
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = DataGridNomenclatureConstants.MaxWeightTraverse,
                    HeaderText = DataGridNomenclatureConstants.MaxWeightHeaderText,
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = DataGridNomenclatureConstants.MaxCountTraverse,
                    HeaderText = DataGridNomenclatureConstants.MaxCountTraverseHeaderText,
                },
            };

            dataGrid.Columns.AddRange(nomenclatures);
        }

        public void CreateStageColumns(DataGridView dataGrid)
        {
            DataGridViewColumn[] stages = new DataGridViewTextBoxColumn[]
            {
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = DataGridNomenclatureConstants.Id,
                    HeaderText = DataGridNomenclatureConstants.IdHeaderText,
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = DataGridNomenclatureConstants.Name,
                    HeaderText = DataGridNomenclatureConstants.NameHeaderText,
                },
                new DataGridViewTextBoxColumn
                {
                    DataPropertyName = DataGridNomenclatureConstants.Date,
                    HeaderText = DataGridNomenclatureConstants.DateHeaderText,
                },
            };

            dataGrid.Columns.AddRange(stages);
        }
    }
}
