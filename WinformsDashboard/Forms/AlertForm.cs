using System;
using System.Windows.Forms;
using WinformsDashboard.DataAccess;

namespace WinformsDashboard.Forms
{
    public partial class AlertForm : Form
    {
        private readonly AlertRepository _alertRepo = new AlertRepository();
        private int _selectedAlertId = 0;

        public AlertForm()
        {
            InitializeComponent();
            this.btnResolve.Click += BtnResolve_Click;
            this.dgvAlerts.CellClick += DgvAlerts_CellClick;
            LoadAlerts();
        }

        private void LoadAlerts()
        {
            dgvAlerts.DataSource = _alertRepo.GetAllAlerts();
            
            var colId = dgvAlerts.Columns["AlertID"];
            if (colId != null) colId.Visible = false;

            var colDevId = dgvAlerts.Columns["DeviceID"];
            if (colDevId != null) colDevId.HeaderText = "Thiết Bị";

            var colLeak = dgvAlerts.Columns["LeakageCurrent"];
            if (colLeak != null) colLeak.HeaderText = "Dòng Rò (mA)";

            var colLevel = dgvAlerts.Columns["AlertLevel"];
            if (colLevel != null) colLevel.HeaderText = "Mức Độ";

            var colDesc = dgvAlerts.Columns["Description"];
            if (colDesc != null) colDesc.HeaderText = "Mô Tả";

            var colTime = dgvAlerts.Columns["AlertTime"];
            if (colTime != null) colTime.HeaderText = "Thời Gian";

            var colResolved = dgvAlerts.Columns["IsResolved"];
            if (colResolved != null) colResolved.HeaderText = "Đã Xử Lý";
            
            btnResolve.Enabled = false;
        }

        private void DgvAlerts_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAlerts.Rows[e.RowIndex];
                if (row.Cells["AlertID"].Value != null)
                    _selectedAlertId = Convert.ToInt32(row.Cells["AlertID"].Value);
                
                bool isResolved = false;
                if (row.Cells["IsResolved"].Value != null)
                    isResolved = Convert.ToBoolean(row.Cells["IsResolved"].Value);
                
                btnResolve.Enabled = !isResolved;
            }
        }

        private void BtnResolve_Click(object? sender, EventArgs e)
        {
            if (_selectedAlertId == 0) return;

            var result = MessageBox.Show("Đánh dấu cảnh báo này là đã xử lý?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _alertRepo.ResolveAlert(_selectedAlertId);
                LoadAlerts();
            }
        }
    }
}


