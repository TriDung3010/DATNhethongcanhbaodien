using System;
using System.Drawing;
using System.Windows.Forms;
using WinformsDashboard.Helpers;
using WinformsDashboard.Services;

namespace WinformsDashboard.Forms
{
    public partial class MainForm : Form
    {
        private Guna.UI2.WinForms.Guna2Button? currentBtn;
        private Form? currentChildForm;
        private string _username = "Admin";

        public MainForm(string username = "Admin")
        {
            InitializeComponent();
            _username = username;


            this.btnDashboard.Click  += BtnDashboard_Click;
            this.btnDevices.Click    += BtnDevices_Click;
            this.btnAlerts.Click     += BtnAlerts_Click;
            this.btnHistory.Click    += BtnHistory_Click;
            this.btnReports.Click    += BtnReports_Click;
            this.btnUsers.Click      += BtnUsers_Click;
            this.btnPowerLoss.Click  += BtnPowerLoss_Click;
            this.btnExit.Click       += BtnExit_Click;

            // Mở Dashboard mặc định
            BtnDashboard_Click(btnDashboard, EventArgs.Empty);

            // Khởi động IoT service
            try
            {
                IoTService.Instance.StartService();
                PowerLossService.Instance.Initialize();
                // Log thành công ra title
                this.Text = "Dashboard - ✅ Server đang lắng nghe cổng 8080";
            }
            catch (Exception ex)
            {
                this.Text = "Dashboard - ❌ Lỗi: " + ex.Message;
                MessageBox.Show(
                    "Không thể khởi động IoT Server trên cổng 8080.\n" +
                    "Lỗi chi tiết: " + ex.Message + "\n\n" +
                    "Kiểm tra xem có app nào khác đang dùng cổng 8080 không.\n" +
                    "(Chạy: netstat -an | findstr 8080 trong PowerShell)",
                    "Lỗi khởi động Server", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDashboard_Click(object? sender, EventArgs e)
        {
            ActivateButton(sender as Guna.UI2.WinForms.Guna2Button);
            OpenChildForm(new DashboardForm());
        }

        private void BtnExit_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnDevices_Click(object? sender, EventArgs e)
        {
            ActivateButton(sender as Guna.UI2.WinForms.Guna2Button);
            OpenChildForm(new DeviceForm());
        }

        private void BtnAlerts_Click(object? sender, EventArgs e)
        {
            ActivateButton(sender as Guna.UI2.WinForms.Guna2Button);
            OpenChildForm(new AlertForm());
        }

        private void BtnHistory_Click(object? sender, EventArgs e)
        {
            ActivateButton(sender as Guna.UI2.WinForms.Guna2Button);
            OpenChildForm(new HistoryForm());
        }

        private void BtnReports_Click(object? sender, EventArgs e)
        {
            ActivateButton(sender as Guna.UI2.WinForms.Guna2Button);
            OpenChildForm(new ReportForm());
        }

        private void BtnUsers_Click(object? sender, EventArgs e)
        {
            ActivateButton(sender as Guna.UI2.WinForms.Guna2Button);
            OpenChildForm(new UserForm());
        }

        private void BtnPowerLoss_Click(object? sender, EventArgs e)
        {
            ActivateButton(sender as Guna.UI2.WinForms.Guna2Button);
            OpenChildForm(new PowerLossAnalysisForm());
        }

        private void ActivateButton(Guna.UI2.WinForms.Guna2Button? btn)
        {
            if (btn == null) return;
            DisableButton();
            currentBtn = btn;
            currentBtn.FillColor  = AppTheme.BgCardHover;
            currentBtn.ForeColor  = AppTheme.AccentBlue;
        }

        private void DisableButton()
        {
            foreach (Control c in pnlSidebar.Controls)
            {
                if (c is Guna.UI2.WinForms.Guna2Button b)
                {
                    b.FillColor = Color.Transparent;
                    b.ForeColor = AppTheme.TextSecond;
                }
            }
        }

        private void OpenChildForm(Form childForm)
        {
            currentChildForm?.Close();
            currentChildForm = childForm;
            childForm.TopLevel   = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock       = DockStyle.Fill;
            pnlContent.Controls.Clear();
            pnlContent.Controls.Add(childForm);
            childForm.Show();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            IoTService.Instance.StopService();
            base.OnFormClosing(e);
        }
    }
}
