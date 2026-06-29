namespace WinformsDashboard.Forms
{
    partial class DeviceForm
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
            txtIPAddress = new Guna.UI2.WinForms.Guna2TextBox();
            lblIPAddress = new Label();
            txtLocation = new Guna.UI2.WinForms.Guna2TextBox();
            lblLocation = new Label();
            txtDeviceName = new Guna.UI2.WinForms.Guna2TextBox();
            lblDeviceName = new Label();
            txtDeviceCode = new Guna.UI2.WinForms.Guna2TextBox();
            lblDeviceCode = new Label();
            dgvDevices = new Guna.UI2.WinForms.Guna2DataGridView();
            pnlToolbar = new Panel();
            btnDelete = new Guna.UI2.WinForms.Guna2GradientButton();
            btnUpdate = new Guna.UI2.WinForms.Guna2GradientButton();
            btnAdd = new Guna.UI2.WinForms.Guna2GradientButton();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            pnlTitleBar = new Panel();
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            pnlInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).BeginInit();
            pnlToolbar.SuspendLayout();
            pnlTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(240, 242, 245);
            pnlMain.Controls.Add(pnlInput);
            pnlMain.Controls.Add(dgvDevices);
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
            pnlInput.BorderRadius = 12;
            pnlInput.Controls.Add(txtIPAddress);
            pnlInput.Controls.Add(lblIPAddress);
            pnlInput.Controls.Add(txtLocation);
            pnlInput.Controls.Add(lblLocation);
            pnlInput.Controls.Add(txtDeviceName);
            pnlInput.Controls.Add(lblDeviceName);
            pnlInput.Controls.Add(txtDeviceCode);
            pnlInput.Controls.Add(lblDeviceCode);
            pnlInput.CustomizableEdges = customizableEdges9;
            pnlInput.Dock = DockStyle.Fill;
            pnlInput.FillColor = Color.FromArgb(255, 255, 255);
            pnlInput.Location = new Point(0, 440);
            pnlInput.Name = "pnlInput";
            pnlInput.Padding = new Padding(20, 15, 20, 15);
            pnlInput.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlInput.Size = new Size(1060, 220);
            pnlInput.TabIndex = 0;
            // 
            // txtIPAddress
            // 
            txtIPAddress.BorderColor = Color.FromArgb(222, 226, 230);
            txtIPAddress.BorderRadius = 6;
            txtIPAddress.CustomizableEdges = customizableEdges1;
            txtIPAddress.DefaultText = "";
            txtIPAddress.FillColor = Color.FromArgb(255, 255, 255);
            txtIPAddress.Font = new Font("Segoe UI", 10F);
            txtIPAddress.ForeColor = Color.FromArgb(33, 37, 41);
            txtIPAddress.Location = new Point(760, 33);
            txtIPAddress.Margin = new Padding(3, 4, 3, 4);
            txtIPAddress.Name = "txtIPAddress";
            txtIPAddress.PlaceholderText = "";
            txtIPAddress.SelectedText = "";
            txtIPAddress.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtIPAddress.Size = new Size(220, 36);
            txtIPAddress.TabIndex = 0;
            // 
            // lblIPAddress
            // 
            lblIPAddress.AutoSize = true;
            lblIPAddress.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblIPAddress.ForeColor = Color.FromArgb(0, 176, 255);
            lblIPAddress.Location = new Point(760, 15);
            lblIPAddress.Name = "lblIPAddress";
            lblIPAddress.Size = new Size(83, 20);
            lblIPAddress.TabIndex = 1;
            lblIPAddress.Text = "ĐỊA CHỈ IP";
            // 
            // txtLocation
            // 
            txtLocation.BorderColor = Color.FromArgb(222, 226, 230);
            txtLocation.BorderRadius = 6;
            txtLocation.CustomizableEdges = customizableEdges3;
            txtLocation.DefaultText = "";
            txtLocation.FillColor = Color.FromArgb(255, 255, 255);
            txtLocation.Font = new Font("Segoe UI", 10F);
            txtLocation.ForeColor = Color.FromArgb(33, 37, 41);
            txtLocation.Location = new Point(510, 33);
            txtLocation.Margin = new Padding(3, 4, 3, 4);
            txtLocation.Name = "txtLocation";
            txtLocation.PlaceholderText = "";
            txtLocation.SelectedText = "";
            txtLocation.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtLocation.Size = new Size(220, 36);
            txtLocation.TabIndex = 2;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLocation.ForeColor = Color.FromArgb(0, 176, 255);
            lblLocation.Location = new Point(510, 15);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(52, 20);
            lblLocation.TabIndex = 3;
            lblLocation.Text = "VỊ TRÍ";
            // 
            // txtDeviceName
            // 
            txtDeviceName.BorderColor = Color.FromArgb(222, 226, 230);
            txtDeviceName.BorderRadius = 6;
            txtDeviceName.CustomizableEdges = customizableEdges5;
            txtDeviceName.DefaultText = "";
            txtDeviceName.FillColor = Color.FromArgb(255, 255, 255);
            txtDeviceName.Font = new Font("Segoe UI", 10F);
            txtDeviceName.ForeColor = Color.FromArgb(33, 37, 41);
            txtDeviceName.Location = new Point(260, 33);
            txtDeviceName.Margin = new Padding(3, 4, 3, 4);
            txtDeviceName.Name = "txtDeviceName";
            txtDeviceName.PlaceholderText = "";
            txtDeviceName.SelectedText = "";
            txtDeviceName.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtDeviceName.Size = new Size(220, 36);
            txtDeviceName.TabIndex = 4;
            // 
            // lblDeviceName
            // 
            lblDeviceName.AutoSize = true;
            lblDeviceName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDeviceName.ForeColor = Color.FromArgb(0, 176, 255);
            lblDeviceName.Location = new Point(260, 15);
            lblDeviceName.Name = "lblDeviceName";
            lblDeviceName.Size = new Size(103, 20);
            lblDeviceName.TabIndex = 5;
            lblDeviceName.Text = "TÊN THIẾT BỊ";
            // 
            // txtDeviceCode
            // 
            txtDeviceCode.BorderColor = Color.FromArgb(222, 226, 230);
            txtDeviceCode.BorderRadius = 6;
            txtDeviceCode.CustomizableEdges = customizableEdges7;
            txtDeviceCode.DefaultText = "";
            txtDeviceCode.FillColor = Color.FromArgb(255, 255, 255);
            txtDeviceCode.Font = new Font("Segoe UI", 10F);
            txtDeviceCode.ForeColor = Color.FromArgb(33, 37, 41);
            txtDeviceCode.Location = new Point(10, 33);
            txtDeviceCode.Margin = new Padding(3, 4, 3, 4);
            txtDeviceCode.Name = "txtDeviceCode";
            txtDeviceCode.PlaceholderText = "";
            txtDeviceCode.SelectedText = "";
            txtDeviceCode.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtDeviceCode.Size = new Size(220, 36);
            txtDeviceCode.TabIndex = 6;
            // 
            // lblDeviceCode
            // 
            lblDeviceCode.AutoSize = true;
            lblDeviceCode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDeviceCode.ForeColor = Color.FromArgb(0, 176, 255);
            lblDeviceCode.Location = new Point(10, 15);
            lblDeviceCode.Name = "lblDeviceCode";
            lblDeviceCode.Size = new Size(99, 20);
            lblDeviceCode.TabIndex = 7;
            lblDeviceCode.Text = "MÃ THIẾT BỊ";
            // 
            // dgvDevices
            // 
            dgvDevices.AllowUserToAddRows = false;
            dgvDevices.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(222, 226, 230);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dgvDevices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvDevices.BackgroundColor = Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvDevices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvDevices.ColumnHeadersHeight = 44;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(222, 226, 230);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvDevices.DefaultCellStyle = dataGridViewCellStyle3;
            dgvDevices.Dock = DockStyle.Top;
            dgvDevices.GridColor = Color.FromArgb(222, 226, 230);
            dgvDevices.Location = new Point(0, 120);
            dgvDevices.Name = "dgvDevices";
            dgvDevices.ReadOnly = true;
            dgvDevices.RowHeadersVisible = false;
            dgvDevices.RowHeadersWidth = 51;
            dgvDevices.RowTemplate.Height = 38;
            dgvDevices.Size = new Size(1060, 320);
            dgvDevices.TabIndex = 1;
            dgvDevices.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvDevices.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 10F);
            dgvDevices.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvDevices.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(222, 226, 230);
            dgvDevices.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dgvDevices.ThemeStyle.BackColor = Color.FromArgb(240, 242, 245);
            dgvDevices.ThemeStyle.GridColor = Color.FromArgb(222, 226, 230);
            dgvDevices.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(240, 242, 245);
            dgvDevices.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvDevices.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvDevices.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDevices.ThemeStyle.HeaderStyle.Height = 44;
            dgvDevices.ThemeStyle.ReadOnly = true;
            dgvDevices.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(255, 255, 255);
            dgvDevices.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10F);
            dgvDevices.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvDevices.ThemeStyle.RowsStyle.Height = 38;
            dgvDevices.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(222, 226, 230);
            dgvDevices.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(33, 37, 41);
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
            pnlToolbar.Padding = new Padding(10);
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
            btnDelete.Location = new Point(553, 11);
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
            btnUpdate.Location = new Point(415, 11);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnUpdate.Size = new Size(132, 36);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "✎  Cập nhật";
            // 
            // btnAdd
            // 
            btnAdd.BorderRadius = 6;
            btnAdd.CustomizableEdges = customizableEdges15;
            btnAdd.FillColor = Color.FromArgb(0, 150, 100);
            btnAdd.FillColor2 = Color.FromArgb(0, 120, 80);
            btnAdd.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(310, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges16;
            btnAdd.Size = new Size(99, 36);
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
            txtSearch.PlaceholderText = "🔍  Tìm kiếm thiết bị...";
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
            pnlTitleBar.Padding = new Padding(20, 0, 0, 0);
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
            lblTitle.Size = new Size(263, 33);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔌  Quản Lý Thiết Bị";
            // 
            // DeviceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(1060, 660);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DeviceForm";
            Text = "DeviceForm";
            pnlMain.ResumeLayout(false);
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).EndInit();
            pnlToolbar.ResumeLayout(false);
            pnlTitleBar.ResumeLayout(false);
            pnlTitleBar.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel             pnlMain;
        private System.Windows.Forms.Panel             pnlTitleBar;
        private System.Windows.Forms.Label             lblTitle;
        private System.Windows.Forms.Panel             pnlToolbar;
        private Guna.UI2.WinForms.Guna2TextBox         txtSearch;
        private Guna.UI2.WinForms.Guna2GradientButton  btnAdd;
        private Guna.UI2.WinForms.Guna2GradientButton  btnUpdate;
        private Guna.UI2.WinForms.Guna2GradientButton  btnDelete;
        private Guna.UI2.WinForms.Guna2DataGridView     dgvDevices;
        private Guna.UI2.WinForms.Guna2Panel            pnlInput;
        private System.Windows.Forms.Label             lblDeviceCode;
        private Guna.UI2.WinForms.Guna2TextBox         txtDeviceCode;
        private System.Windows.Forms.Label             lblDeviceName;
        private Guna.UI2.WinForms.Guna2TextBox         txtDeviceName;
        private System.Windows.Forms.Label             lblLocation;
        private Guna.UI2.WinForms.Guna2TextBox         txtLocation;
        private System.Windows.Forms.Label             lblIPAddress;
        private Guna.UI2.WinForms.Guna2TextBox         txtIPAddress;
    }
}

