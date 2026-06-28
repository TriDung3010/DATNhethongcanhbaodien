using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace WinformsDashboard
{
    public partial class frmRoomManager : Form
    {
        private BindingList<RoomConfig> _roomsList;

        public frmRoomManager()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var rooms = RoomManager.LoadRooms();
            _roomsList = new BindingList<RoomConfig>(rooms);
            dgvRooms.DataSource = _roomsList;

            dgvRooms.Columns["DeviceId"].HeaderText = "Mã thiết bị (DeviceId)";
            dgvRooms.Columns["RoomName"].HeaderText = "Tên phòng hiển thị";
            dgvRooms.Columns["ThresholdAlert"].HeaderText = "Ngưỡng Cảnh Báo (mA)";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Convert BindingList to List
            var listToSave = new List<RoomConfig>();
            foreach (var item in _roomsList)
            {
                if (!string.IsNullOrWhiteSpace(item.DeviceId) && !string.IsNullOrWhiteSpace(item.RoomName))
                {
                    listToSave.Add(item);
                }
            }

            RoomManager.SaveRooms(listToSave);
            MessageBox.Show("Lưu danh sách phòng thành công!\nHãy khởi động lại phần mềm để áp dụng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
