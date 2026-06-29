using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using WinformsDashboard.DataAccess;

namespace WinformsDashboard.Forms
{
    public partial class HistoryForm : Form
    {
        private readonly SensorDataRepository _sensorRepo = new SensorDataRepository();

        public HistoryForm()
        {
            InitializeComponent();
            LoadHistory();
            btnExport.Click += BtnExport_Click;
        }

        private void BtnExport_Click(object? sender, EventArgs e)
        {
            if (dgvHistory.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "CSV files|*.csv", FileName = "LichSuCamBien.csv" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("Ma Thiet Bi,Dien Ap (V),Dong Dien (A),Dong Ro (mA),Thoi Gian");

                        foreach (DataGridViewRow row in dgvHistory.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string devId = row.Cells["DeviceID"].Value?.ToString() ?? "";
                                string vol = row.Cells["Voltage"].Value?.ToString() ?? "";
                                string cur = row.Cells["CurrentValue"].Value?.ToString() ?? "";
                                string leak = row.Cells["LeakageCurrent"].Value?.ToString() ?? "";
                                string time = row.Cells["CreatedAt"].Value?.ToString() ?? "";
                                sb.AppendLine($"{devId},{vol},{cur},{leak},{time}");
                            }
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        MessageBox.Show("Xuất file Excel (CSV) thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LoadHistory()
        {
            dgvHistory.DataSource = _sensorRepo.GetRecentData(100);
            
            var colId = dgvHistory.Columns["DataID"];
            if (colId != null) colId.Visible = false;

            var colDev = dgvHistory.Columns["DeviceID"];
            if (colDev != null) colDev.HeaderText = "Thiết Bị";

            var colVolt = dgvHistory.Columns["Voltage"];
            if (colVolt != null) colVolt.HeaderText = "Điện Áp (V)";

            var colCur = dgvHistory.Columns["CurrentValue"];
            if (colCur != null) colCur.HeaderText = "Dòng Điện (A)";

            var colLeak = dgvHistory.Columns["LeakageCurrent"];
            if (colLeak != null) colLeak.HeaderText = "Dòng Rò (mA)";

            var colTime = dgvHistory.Columns["CreatedAt"];
            if (colTime != null) colTime.HeaderText = "Thời Gian";
        }
    }
}
