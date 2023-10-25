using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SZGC.Desktop.Views.Setting.Interfaces;

namespace SZGC.Desktop.Views.Setting
{
    public partial class SettingView : Form, ISettingView
    {
        public event Action Start;
        public event Action Save;

        public Form Form => this;

        public string WorkingShift { get => WorkingShift_TB.Text; set => WorkingShift_TB.Text = value; }

        public SettingView()
        {
            InitializeComponent();
        }

        private void SettingView_Load(object sender, EventArgs e)
        {
            Start?.Invoke();
        }

        private void Save_B_Click(object sender, EventArgs e)
        {
            Save?.Invoke();
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
