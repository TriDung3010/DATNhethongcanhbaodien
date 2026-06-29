using System;
using System.Windows.Forms;
using WinformsDashboard.DataAccess;
using WinformsDashboard.Models;

namespace WinformsDashboard.Forms
{
    public partial class DeviceForm : Form
    {
        private readonly DeviceRepository _deviceRepo = new DeviceRepository();
        private int _selectedDeviceId = 0;

        public DeviceForm()
        {
            InitializeComponent();
            this.btnAdd.Click += BtnAdd_Click;
            this.btnUpdate.Click += BtnUpdate_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.dgvDevices.CellClick += DgvDevices_CellClick;
            LoadDevices();
        }

        private void LoadDevices()
        {
            dgvDevices.DataSource = _deviceRepo.GetAllDevices();
            
            var colId = dgvDevices.Columns["DeviceID"];
            if (colId != null) colId.Visible = false;

            var colCode = dgvDevices.Columns["DeviceCode"];
            if (colCode != null) colCode.HeaderText = "Mã Thiết Bị";

            var colName = dgvDevices.Columns["DeviceName"];
            if (colName != null) colName.HeaderText = "Tên Thiết Bị";

            var colLoc = dgvDevices.Columns["Location"];
            if (colLoc != null) colLoc.HeaderText = "Vị Trí Lắp Đặt";

            var colIP = dgvDevices.Columns["IPAddress"];
            if (colIP != null) colIP.HeaderText = "Địa chỉ IP";

            var colStatus = dgvDevices.Columns["Status"];
            if (colStatus != null) colStatus.HeaderText = "Trạng Thái";
            
            ClearInputs();
        }

        private void ClearInputs()
        {
            _selectedDeviceId = 0;
            txtDeviceCode.Clear();
            txtDeviceName.Clear();
            txtLocation.Clear();
            txtDeviceCode.ReadOnly = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            ClearInputs();
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDeviceCode.Text) || string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                MessageBox.Show("Vui lòng nhập mã và tên thiết bị!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var device = new Device
            {
                DeviceCode = txtDeviceCode.Text.Trim(),
                DeviceName = txtDeviceName.Text.Trim(),
                Location = txtLocation.Text.Trim()
            };

            _deviceRepo.AddDevice(device);
            LoadDevices();
            MessageBox.Show("Thêm thiết bị thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DgvDevices_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDevices.Rows[e.RowIndex];
                _selectedDeviceId = Convert.ToInt32(row.Cells["DeviceID"].Value);
                txtDeviceCode.Text = row.Cells["DeviceCode"].Value?.ToString() ?? "";
                txtDeviceName.Text = row.Cells["DeviceName"].Value?.ToString() ?? "";
                txtLocation.Text = row.Cells["Location"].Value?.ToString() ?? "";
                
                txtDeviceCode.ReadOnly = true;
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            if (_selectedDeviceId == 0) return;

            if (string.IsNullOrWhiteSpace(txtDeviceName.Text))
            {
                MessageBox.Show("Tên thiết bị không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var device = new Device
            {
                DeviceID = _selectedDeviceId,
                DeviceCode = txtDeviceCode.Text.Trim(),
                DeviceName = txtDeviceName.Text.Trim(),
                Location = txtLocation.Text.Trim()
            };

            _deviceRepo.UpdateDevice(device);
            LoadDevices();
            MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedDeviceId == 0) return;

            var result = MessageBox.Show("Bạn có chắc chắn muốn xóa thiết bị này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _deviceRepo.DeleteDevice(_selectedDeviceId);
                LoadDevices();
            }
        }
    }
}

