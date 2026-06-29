namespace WinformsDashboard.Forms
{
    partial class UserForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlMain = new Panel();
            pnlInput = new Guna.UI2.WinForms.Guna2Panel();
            cmbRole = new Guna.UI2.WinForms.Guna2ComboBox();
            lblRole = new Label();
            txtFullName = new Guna.UI2.WinForms.Guna2TextBox();
            lblFullName = new Label();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            lblPassword = new Label();
            txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            lblUsername = new Label();
            dgvUsers = new Guna.UI2.WinForms.Guna2DataGridView();
            pnlToolbar = new Panel();
            btnDelete = new Guna.UI2.WinForms.Guna2GradientButton();
            btnUpdate = new Guna.UI2.WinForms.Guna2GradientButton();
            btnAdd = new Guna.UI2.WinForms.Guna2GradientButton();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            pnlTitleBar = new Panel();
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            pnlToolbar.SuspendLayout();
            pnlTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(240, 242, 245);
            pnlMain.Controls.Add(pnlInput);
            pnlMain.Controls.Add(dgvUsers);
            pnlMain.Controls.Add(pnlToolbar);
            pnlMain.Controls.Add(pnlTitleBar);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1060, 660);
            pnlMain.TabIndex = 0;
            // 
            // pnlInput
            // 
            pnlInput.BackColor = Color.Transparent;
            pnlInput.BorderRadius = 10;
            pnlInput.Controls.Add(cmbRole);
            pnlInput.Controls.Add(lblRole);
            pnlInput.Controls.Add(txtFullName);
            pnlInput.Controls.Add(lblFullName);
            pnlInput.Controls.Add(txtPassword);
            pnlInput.Controls.Add(lblPassword);
            pnlInput.Controls.Add(txtUsername);
            pnlInput.Controls.Add(lblUsername);
            pnlInput.CustomizableEdges = customizableEdges9;
            pnlInput.Dock = DockStyle.Fill;
            pnlInput.FillColor = Color.FromArgb(255, 255, 255);
            pnlInput.Location = new Point(0, 420);
            pnlInput.Name = "pnlInput";
            pnlInput.Padding = new Padding(20, 15, 20, 15);
            pnlInput.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlInput.Size = new Size(1060, 240);
            pnlInput.TabIndex = 0;
            // 
            // cmbRole
            // 
            cmbRole.BackColor = Color.Transparent;
            cmbRole.BorderRadius = 6;
            cmbRole.CustomizableEdges = customizableEdges1;
            cmbRole.DrawMode = DrawMode.OwnerDrawFixed;
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.FillColor = Color.FromArgb(255, 255, 255);
            cmbRole.FocusedColor = Color.Empty;
            cmbRole.Font = new Font("Segoe UI", 10F);
            cmbRole.ForeColor = Color.FromArgb(33, 37, 41);
            cmbRole.ItemHeight = 32;
            cmbRole.Items.AddRange(new object[] { "Admin", "User" });
            cmbRole.Location = new Point(700, 28);
            cmbRole.Name = "cmbRole";
            cmbRole.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cmbRole.Size = new Size(160, 38);
            cmbRole.TabIndex = 0;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(0, 176, 255);
            lblRole.Location = new Point(700, 10);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(68, 20);
            lblRole.TabIndex = 1;
            lblRole.Text = "VAI TRÒ";
            // 
            // txtFullName
            // 
            txtFullName.BorderColor = Color.FromArgb(222, 226, 230);
            txtFullName.BorderRadius = 6;
            txtFullName.CustomizableEdges = customizableEdges3;
            txtFullName.DefaultText = "";
            txtFullName.FillColor = Color.FromArgb(255, 255, 255);
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.ForeColor = Color.FromArgb(33, 37, 41);
            txtFullName.Location = new Point(470, 28);
            txtFullName.Margin = new Padding(3, 4, 3, 4);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "";
            txtFullName.SelectedText = "";
            txtFullName.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtFullName.Size = new Size(200, 36);
            txtFullName.TabIndex = 2;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFullName.ForeColor = Color.FromArgb(0, 176, 255);
            lblFullName.Location = new Point(470, 10);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(88, 20);
            lblFullName.TabIndex = 3;
            lblFullName.Text = "HỌ VÀ TÊN";
            // 
            // txtPassword
            // 
            txtPassword.BorderColor = Color.FromArgb(222, 226, 230);
            txtPassword.BorderRadius = 6;
            txtPassword.CustomizableEdges = customizableEdges5;
            txtPassword.DefaultText = "";
            txtPassword.FillColor = Color.FromArgb(255, 255, 255);
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.ForeColor = Color.FromArgb(33, 37, 41);
            txtPassword.Location = new Point(240, 28);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.PlaceholderText = "";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtPassword.Size = new Size(200, 36);
            txtPassword.TabIndex = 4;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(0, 176, 255);
            lblPassword.Location = new Point(240, 10);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(90, 20);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "MẬT KHẨU";
            // 
            // txtUsername
            // 
            txtUsername.BorderColor = Color.FromArgb(222, 226, 230);
            txtUsername.BorderRadius = 6;
            txtUsername.CustomizableEdges = customizableEdges7;
            txtUsername.DefaultText = "";
            txtUsername.FillColor = Color.FromArgb(255, 255, 255);
            txtUsername.Font = new Font("Segoe UI", 10F);
            txtUsername.ForeColor = Color.FromArgb(33, 37, 41);
            txtUsername.Location = new Point(10, 28);
            txtUsername.Margin = new Padding(3, 4, 3, 4);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "";
            txtUsername.SelectedText = "";
            txtUsername.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtUsername.Size = new Size(200, 36);
            txtUsername.TabIndex = 6;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(0, 176, 255);
            lblUsername.Location = new Point(10, 10);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(92, 20);
            lblUsername.TabIndex = 7;
            lblUsername.Text = "TÀI KHOẢN";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(222, 226, 230);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsers.BackgroundColor = Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvUsers.ColumnHeadersHeight = 44;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(222, 226, 230);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvUsers.DefaultCellStyle = dataGridViewCellStyle3;
            dgvUsers.Dock = DockStyle.Top;
            dgvUsers.GridColor = Color.FromArgb(222, 226, 230);
            dgvUsers.Location = new Point(0, 120);
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.RowTemplate.Height = 38;
            dgvUsers.Size = new Size(1060, 300);
            dgvUsers.TabIndex = 1;
            dgvUsers.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvUsers.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 10F);
            dgvUsers.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvUsers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(222, 226, 230);
            dgvUsers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dgvUsers.ThemeStyle.BackColor = Color.FromArgb(240, 242, 245);
            dgvUsers.ThemeStyle.GridColor = Color.FromArgb(222, 226, 230);
            dgvUsers.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(240, 242, 245);
            dgvUsers.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvUsers.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvUsers.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvUsers.ThemeStyle.HeaderStyle.Height = 44;
            dgvUsers.ThemeStyle.ReadOnly = true;
            dgvUsers.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(255, 255, 255);
            dgvUsers.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10F);
            dgvUsers.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvUsers.ThemeStyle.RowsStyle.Height = 38;
            dgvUsers.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(222, 226, 230);
            dgvUsers.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(33, 37, 41);
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.FromArgb(255, 255, 255);
            pnlToolbar.Controls.Add(btnDelete);
            pnlToolbar.Controls.Add(btnUpdate);
            pnlToolbar.Controls.Add(btnAdd);
            pnlToolbar.Controls.Add(txtSearch);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 60);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Padding = new Padding(10, 12, 10, 12);
            pnlToolbar.Size = new Size(1060, 60);
            pnlToolbar.TabIndex = 2;
            // 
            // btnDelete
            // 
            btnDelete.BorderRadius = 6;
            btnDelete.CustomizableEdges = customizableEdges11;
            btnDelete.FillColor = Color.FromArgb(180, 30, 50);
            btnDelete.FillColor2 = Color.FromArgb(140, 20, 40);
            btnDelete.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(550, 12);
            btnDelete.Name = "btnDelete";
            btnDelete.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnDelete.Size = new Size(110, 36);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "🗑  Xóa";
            // 
            // btnUpdate
            // 
            btnUpdate.BorderRadius = 6;
            btnUpdate.CustomizableEdges = customizableEdges13;
            btnUpdate.FillColor = Color.FromArgb(0, 120, 180);
            btnUpdate.FillColor2 = Color.FromArgb(0, 95, 145);
            btnUpdate.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(430, 12);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnUpdate.Size = new Size(110, 36);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "✎  Sửa";
            // 
            // btnAdd
            // 
            btnAdd.BorderRadius = 6;
            btnAdd.CustomizableEdges = customizableEdges15;
            btnAdd.FillColor = Color.FromArgb(0, 150, 100);
            btnAdd.FillColor2 = Color.FromArgb(0, 120, 80);
            btnAdd.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(310, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnAdd.Size = new Size(110, 36);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "＋  Thêm";
            // 
            // txtSearch
            // 
            txtSearch.BorderColor = Color.FromArgb(0, 176, 255);
            txtSearch.BorderRadius = 20;
            txtSearch.CustomizableEdges = customizableEdges17;
            txtSearch.DefaultText = "";
            txtSearch.FillColor = Color.FromArgb(255, 255, 255);
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.FromArgb(33, 37, 41);
            txtSearch.Location = new Point(10, 12);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍  Tìm kiếm người dùng...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges18;
            txtSearch.Size = new Size(280, 36);
            txtSearch.TabIndex = 3;
            // 
            // pnlTitleBar
            // 
            pnlTitleBar.BackColor = Color.Transparent;
            pnlTitleBar.Controls.Add(lblTitle);
            pnlTitleBar.Dock = DockStyle.Top;
            pnlTitleBar.Location = new Point(0, 0);
            pnlTitleBar.Name = "pnlTitleBar";
            pnlTitleBar.Size = new Size(1060, 60);
            pnlTitleBar.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Emoji", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(319, 33);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "👤  Quản Lý Người Dùng";
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(1060, 660);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserForm";
            Text = "UserForm";
            pnlMain.ResumeLayout(false);
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            pnlToolbar.ResumeLayout(false);
            pnlTitleBar.ResumeLayout(false);
            pnlTitleBar.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel            pnlMain;
        private System.Windows.Forms.Panel            pnlTitleBar;
        private System.Windows.Forms.Label            lblTitle;
        private System.Windows.Forms.Panel            pnlToolbar;
        private Guna.UI2.WinForms.Guna2TextBox        txtSearch;
        private Guna.UI2.WinForms.Guna2GradientButton btnAdd;
        private Guna.UI2.WinForms.Guna2GradientButton btnUpdate;
        private Guna.UI2.WinForms.Guna2GradientButton btnDelete;
        private Guna.UI2.WinForms.Guna2DataGridView   dgvUsers;
        private Guna.UI2.WinForms.Guna2Panel          pnlInput;
        private System.Windows.Forms.Label            lblUsername;
        private Guna.UI2.WinForms.Guna2TextBox        txtUsername;
        private System.Windows.Forms.Label            lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox        txtPassword;
        private System.Windows.Forms.Label            lblFullName;
        private Guna.UI2.WinForms.Guna2TextBox        txtFullName;
        private System.Windows.Forms.Label            lblRole;
        private Guna.UI2.WinForms.Guna2ComboBox       cmbRole;
    }
}

