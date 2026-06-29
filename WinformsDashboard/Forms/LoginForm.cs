using System;
using System.Windows.Forms;
using WinformsDashboard.Services;

namespace WinformsDashboard.Forms
{
    public partial class LoginForm : Form
    {
        private AuthService _authService = new AuthService();

        public LoginForm()
        {
            InitializeComponent();
            this.btnLogin.Click += BtnLogin_Click;
            this.txtUsername.KeyDown += TxtInput_KeyDown;
            this.txtPassword.KeyDown += TxtInput_KeyDown;
        }

        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Ngăn tiếng bíp (nếu có)
                btnLogin.PerformClick();
            }
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            lblError.Text = "";
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Vui lòng nhập đầy đủ thông tin!";
                return;
            }

            try
            {
                if (_authService.Login(username, password))
                {
                    MainForm main = new MainForm();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    lblError.Text = "Sai tài khoản hoặc mật khẩu!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


