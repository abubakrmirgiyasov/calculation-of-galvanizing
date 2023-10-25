using System;
using System.Net;
using System.Windows.Forms;
using SZGC.Desktop.Views.Auth.Interfaces;

namespace SZGC.Desktop.Views.Auth
{
    public partial class AuthView : Form, IAuthVIew
    {
        private readonly ApplicationContext _context;

        public Form Form => this;

        public string UserName { get => Login_TB.Text.Trim(); set => Login_TB.Text = value; }

        public string Password { get => Password_TB.Text.Trim(); set => Password_TB.Text = value; }

        public bool RememberMe { get => RememberMe_CB.Checked; set => RememberMe_CB.Checked = value; }

        public event Action Start;

        public event Action Login;

        public AuthView(ApplicationContext context)
        {
            _context = context;

            InitializeComponent();

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

        }

        public new void Show()
        {
            try
            {
                _context.MainForm = this;
                Application.Run(_context);
            }
            catch (InvalidOperationException)
            {
                base.Show();
            }
        }

        private void AuthView_Load(object sender, EventArgs e)
        {
            Start?.Invoke();
        }

        public void BlockFields(bool flag)
        {
            Login_TB.ReadOnly = flag;
            Password_TB.ReadOnly = flag;
            RememberMe_CB.Enabled = !flag;
        }

        public void SetNameLogin_B(string name)
        {
            Login_B?.Invoke((MethodInvoker)delegate ()
            {
                Login_B.Text = name;
            });
        }

        private void Login_B_Click(object sender, EventArgs e)
        {
            Login?.Invoke();
        }

        public void Error(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Info(string message)
        {
            MessageBox.Show(message, "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Warning(string message)
        {
            MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
