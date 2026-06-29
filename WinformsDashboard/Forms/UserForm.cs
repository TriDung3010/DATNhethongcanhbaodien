using System;
using System.Windows.Forms;
using WinformsDashboard.DataAccess;
using WinformsDashboard.Helpers;
using WinformsDashboard.Models;

namespace WinformsDashboard.Forms
{
    public partial class UserForm : Form
    {
        private readonly UserRepository _userRepo = new UserRepository();
        private int _selectedUserId = 0;

        public UserForm()
        {
            InitializeComponent();
            this.btnAdd.Click += BtnAdd_Click;
            this.btnUpdate.Click += BtnUpdate_Click;
            this.btnDelete.Click += BtnDelete_Click;
            this.dgvUsers.CellClick += DgvUsers_CellClick;
            LoadUsers();
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = _userRepo.GetAllUsers();
            
            var colId = dgvUsers.Columns["UserID"];
            if (colId != null) colId.Visible = false;

            var colHash = dgvUsers.Columns["PasswordHash"];
            if (colHash != null) colHash.Visible = false;

            var colUser = dgvUsers.Columns["Username"];
            if (colUser != null) colUser.HeaderText = "Tên Đăng Nhập";

            var colRole = dgvUsers.Columns["Role"];
            if (colRole != null) colRole.HeaderText = "Quyền";
            
            ClearInputs();
        }

        private void ClearInputs()
        {
            _selectedUserId = 0;
            txtUsername.Clear();
            txtUsername.Enabled = true;
            txtPassword.Clear();
            cmbRole.SelectedIndex = 1; // Default User
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            btnAdd.Enabled = true;
        }

        private void DgvUsers_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsers.Rows[e.RowIndex];
                _selectedUserId = Convert.ToInt32(row.Cells["UserID"].Value);
                txtUsername.Text = row.Cells["Username"].Value?.ToString() ?? "";
                txtUsername.Enabled = false; // Không cho sửa Username
                
                string role = row.Cells["Role"].Value?.ToString() ?? "User";
                cmbRole.SelectedItem = role;
                
                btnAdd.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên đăng nhập và Mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var existing = _userRepo.GetUserByUsername(txtUsername.Text);
            if (existing != null)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = new User
            {
                Username = txtUsername.Text,
                PasswordHash = PasswordHasher.HashPassword(txtPassword.Text),
                Role = cmbRole.SelectedItem?.ToString() ?? "User"
            };

            if (_userRepo.AddUser(user))
            {
                MessageBox.Show("Thêm người dùng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
        }

        private void BtnUpdate_Click(object? sender, EventArgs e)
        {
            if (_selectedUserId == 0) return;

            string role = cmbRole.SelectedItem?.ToString() ?? "User";
            _userRepo.UpdateUserRole(_selectedUserId, role);
            
            // Nu nhp m-t khu m>i thA update pass
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                _userRepo.UpdatePassword(_selectedUserId, PasswordHasher.HashPassword(txtPassword.Text));
            }

            MessageBox.Show("Cập nhật thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadUsers();
        }

        private void BtnDelete_Click(object? sender, EventArgs e)
        {
            if (_selectedUserId == 0) return;
            
            if (txtUsername.Text == "admin")
            {
                MessageBox.Show("Không được phép xóa tài khoản admin mặc định!", "Từ chối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc muốn xóa người dùng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (_userRepo.DeleteUser(_selectedUserId))
                {
                    MessageBox.Show("Xóa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUsers();
                }
            }
        }
    }
}

