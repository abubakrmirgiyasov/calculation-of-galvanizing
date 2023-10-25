using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SZGC.Desktop.Views.Main.Interfaces;
using SZGC.Domain.ViewModels;

namespace SZGC.Desktop.Views.Main
{
    public partial class MainView : Form, IMainView
    {
        private readonly ApplicationContext _context;

        private bool _cancel = true;

        public event Action Start;
        public event Action Finish;
        public event Action Settings;
        public event Action Nomenclature;
        public event Action Order;
        public event Action Stage;
        public event Action Add;
        public event Action Edit;
        public event Action Remove;
        public event Action Search;
        public event Action Reset;
        public event Action DoubleClickToDataGrid;
        public event Action AdvancedSearch;
        public event Action AddBasedOn;

        public string SearchText { get => Search_TB_TSB.Text; set => Search_TB_TSB.Text = value; }

        public bool Cancel { get => _cancel; set => _cancel = value; }

        public bool SelectedRow { get => Main_DGV.SelectedRows.Count == 1; }

        public Form Form => this;

        public string ButtonTag { get; set; }

        public int SelectedRowPosition { get; set; }

        public Guid SelectedRowId { get; set; }

        public StageViewModel SelectedRowStage { get; set; }

        public MainView(ApplicationContext context)
        {
            _context = context;

            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            Func_TS.Renderer = new ToolStripProfessionalRenderer() { RoundedEdges = false };
            Main_TS.Renderer = new ToolStripProfessionalRenderer() { RoundedEdges = false };

            ButtonTag = Order_TSB.Tag.ToString();

            if (ButtonTag == Order_TSB.Tag.ToString())
            {
                new Column().CreateOrderColumns(Main_DGV);
            }

            Main_DGV.AutoGenerateColumns = false;

            Start?.Invoke();
        }

        public new void Show()
        {
            _context.MainForm = this;
            base.Show();
        }

        private void Settings_TSMI_Click(object sender, EventArgs e)
        {
            Settings?.Invoke();
        }

        private void Hide_TSB_Click(object sender, EventArgs e)
        {
            if (Main_TLP.ColumnStyles[0].Width == 200)
            {
                Hide_TSB.Image = Properties.Resources.Right;
                HideFunctionButton(true);
                Main_TLP.ColumnStyles[0].Width = 40;
            }
            else
            {
                HideFunctionButton(false);
                Hide_TSB.Image = Properties.Resources.Left;
                Main_TLP.ColumnStyles[0].Width = 200;
            }
        }

        private void HideFunctionButton(bool flag)
        {
            if (flag)
            {
                Order_TSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
                Nomenclature_TSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
                Stage_TSB.DisplayStyle = ToolStripItemDisplayStyle.Image;
            }
            else
            {
                Order_TSB.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                Nomenclature_TSB.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                Stage_TSB.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            }
        }

        private void Nomenclature_TSB_Click(object sender, EventArgs e)
        {
            Nomenclature?.Invoke();
            Main_DGV.Columns.Clear();

            new Column().CreateNomenclatureColumns(Main_DGV);

            Main_DGV.ContextMenuStrip = ContextMenuStrip;

            ButtonTag = Nomenclature_TSB.Tag.ToString();
            Nomenclature_TSB.ForeColor = Color.FromArgb(224, 224, 224);
            Order_TSB.ForeColor = Color.FromArgb(34, 150, 201);
            Stage_TSB.ForeColor = Color.FromArgb(34, 150, 201);
        }

        private void Stages_TSB_Click(object sender, EventArgs e)
        {
            Stage?.Invoke();
            Main_DGV.Columns.Clear();

            new Column().CreateStageColumns(Main_DGV);

            Main_DGV.ContextMenuStrip = null;

            ButtonTag = Stage_TSB.Tag.ToString();
            Stage_TSB.ForeColor = Color.FromArgb(224, 224, 224);
            Order_TSB.ForeColor = Color.FromArgb(34, 150, 201);
            Nomenclature_TSB.ForeColor = Color.FromArgb(34, 150, 201);
        }

        private void Order_TSB_Click(object sender, EventArgs e)
        {
            Order?.Invoke();
            Main_DGV.Columns.Clear();

            new Column().CreateOrderColumns(Main_DGV);

            Main_DGV.ContextMenuStrip = null;

            ButtonTag = Order_TSB.Tag.ToString();
            Order_TSB.ForeColor = Color.FromArgb(224, 224, 224);
            Stage_TSB.ForeColor = Color.FromArgb(34, 150, 201);
            Nomenclature_TSB.ForeColor = Color.FromArgb(34, 150, 201);
        }

        private void Main_DGV_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.RowIndex != -1)
            {
                DoubleClickToDataGrid?.Invoke();
            }
        }

        private void Add_TSB_Click(object sender, EventArgs e)
        {
            Add?.Invoke();
        }

        private void Edit_TSB_Click(object sender, EventArgs e)
        {
            Edit?.Invoke();
        }

        private void Delete_TSB_Click(object sender, EventArgs e)
        {
            Remove?.Invoke();
        }

        private void Search_B_TSB_Click_1(object sender, EventArgs e)
        {
            Search?.Invoke();
        }

        private void Reset_TSB_Click(object sender, EventArgs e)
        {
            Reset?.Invoke();
        }

        public void ShowData<T>(List<T> items)
        {
            Main_DGV.DataSource = null;
            Main_DGV.DataSource = items;
            Main_DGV.ClearSelection();
        }

        public T DataBoundItem<T>() where T : class
        {
            if (Main_DGV.SelectedRows.Count == 1)
            {
                return Main_DGV.SelectedRows[0].DataBoundItem as T;
            }
            else
            {
                throw new Exception("Вы не выбрали запись");
            }
        }
        private void AdvancedSearch_TSB_Click(object sender, EventArgs e)
        {
            AdvancedSearch?.Invoke();
        }

        private void CreateBaseOn_TSMI_Click(object sender, EventArgs e)
        {
            AddBasedOn?.Invoke();
        }

        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = _cancel;

            if (e.Cancel)
            {
                Finish?.Invoke();
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
