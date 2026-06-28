using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinformsDashboard
{
    public partial class frmMain : Form
    {
        private Form _activeForm;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Tự động load Dashboard khi khởi động
            OpenChildForm(new frmDashboard(), btnDashboard);
        }

        private void OpenChildForm(Form childForm, Button senderButton)
        {
            if (_activeForm != null)
            {
                // Không đóng hẳn frmDashboard vì nó đang giữ HttpListener, 
                // nhưng với kiến trúc này tốt nhất ta chỉ Hide() nó đi hoặc tách HttpListener ra
                // Tạm thời, nếu đổi qua form khác, ta ẩn form hiện tại.
                _activeForm.Hide();
            }

            _activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            // Highlight button
            ResetButtonColors();
            senderButton.BackColor = Color.FromArgb(46, 160, 67);
        }

        private void ResetButtonColors()
        {
            btnDashboard.BackColor = Color.FromArgb(22, 27, 34);
            btnHistory.BackColor = Color.FromArgb(22, 27, 34);
            btnRoomManager.BackColor = Color.FromArgb(22, 27, 34);
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            // Vì frmDashboard đang giữ server ngầm, ta nên dùng instance duy nhất nếu có thể,
            // hoặc tái sử dụng instance cũ đang nằm trong pnlContent.Controls
            var dash = GetExistingForm<frmDashboard>();
            if (dash == null)
            {
                dash = new frmDashboard();
            }
            else
            {
                dash.ReloadRoomsConfig();
            }
            OpenChildForm(dash, btnDashboard);
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tính năng Lịch sử đang được phát triển.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRoomManager_Click(object sender, EventArgs e)
        {
            var roomForm = GetExistingForm<frmRoomManager>();
            OpenChildForm(roomForm ?? new frmRoomManager(), btnRoomManager);
        }

        private T GetExistingForm<T>() where T : Form
        {
            foreach (Control ctrl in pnlContent.Controls)
            {
                if (ctrl is T form)
                {
                    return form;
                }
            }
            return null;
        }
    }
}
