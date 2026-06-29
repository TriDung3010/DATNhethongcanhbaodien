namespace WinformsDashboard.Forms
{
    partial class AlertForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlMain = new Panel();
            dgvAlerts = new Guna.UI2.WinForms.Guna2DataGridView();
            pnlToolbar = new Panel();
            btnResolve = new Guna.UI2.WinForms.Guna2GradientButton();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            pnlTitleBar = new Panel();
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAlerts).BeginInit();
            pnlToolbar.SuspendLayout();
            pnlTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(240, 242, 245);
            pnlMain.Controls.Add(dgvAlerts);
            pnlMain.Controls.Add(pnlToolbar);
            pnlMain.Controls.Add(pnlTitleBar);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1060, 660);
            pnlMain.TabIndex = 0;
            // 
            // dgvAlerts
            // 
            dgvAlerts.AllowUserToAddRows = false;
            dgvAlerts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(222, 226, 230);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dgvAlerts.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAlerts.BackgroundColor = Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAlerts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAlerts.ColumnHeadersHeight = 44;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(222, 226, 230);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvAlerts.DefaultCellStyle = dataGridViewCellStyle3;
            dgvAlerts.Dock = DockStyle.Fill;
            dgvAlerts.GridColor = Color.FromArgb(222, 226, 230);
            dgvAlerts.Location = new Point(0, 120);
            dgvAlerts.Name = "dgvAlerts";
            dgvAlerts.ReadOnly = true;
            dgvAlerts.RowHeadersVisible = false;
            dgvAlerts.RowHeadersWidth = 51;
            dgvAlerts.RowTemplate.Height = 38;
            dgvAlerts.Size = new Size(1060, 540);
            dgvAlerts.TabIndex = 0;
            dgvAlerts.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvAlerts.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 10F);
            dgvAlerts.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvAlerts.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(222, 226, 230);
            dgvAlerts.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dgvAlerts.ThemeStyle.BackColor = Color.FromArgb(240, 242, 245);
            dgvAlerts.ThemeStyle.GridColor = Color.FromArgb(222, 226, 230);
            dgvAlerts.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(240, 242, 245);
            dgvAlerts.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvAlerts.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvAlerts.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAlerts.ThemeStyle.HeaderStyle.Height = 44;
            dgvAlerts.ThemeStyle.ReadOnly = true;
            dgvAlerts.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(255, 255, 255);
            dgvAlerts.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10F);
            dgvAlerts.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvAlerts.ThemeStyle.RowsStyle.Height = 38;
            dgvAlerts.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(222, 226, 230);
            dgvAlerts.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(33, 37, 41);
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.FromArgb(255, 255, 255);
            pnlToolbar.Controls.Add(btnResolve);
            pnlToolbar.Controls.Add(txtSearch);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 60);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Padding = new Padding(10, 12, 10, 12);
            pnlToolbar.Size = new Size(1060, 60);
            pnlToolbar.TabIndex = 1;
            // 
            // btnResolve
            // 
            btnResolve.BorderRadius = 6;
            btnResolve.CustomizableEdges = customizableEdges1;
            btnResolve.FillColor = Color.FromArgb(0, 150, 100);
            btnResolve.FillColor2 = Color.FromArgb(0, 120, 80);
            btnResolve.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Bold);
            btnResolve.ForeColor = Color.White;
            btnResolve.Location = new Point(310, 12);
            btnResolve.Name = "btnResolve";
            btnResolve.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnResolve.Size = new Size(130, 36);
            btnResolve.TabIndex = 0;
            btnResolve.Text = "✅  Đã Xử Lý";
            // 
            // txtSearch
            // 
            txtSearch.BorderColor = Color.FromArgb(0, 176, 255);
            txtSearch.BorderRadius = 20;
            txtSearch.CustomizableEdges = customizableEdges3;
            txtSearch.DefaultText = "";
            txtSearch.FillColor = Color.FromArgb(255, 255, 255);
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.FromArgb(33, 37, 41);
            txtSearch.Location = new Point(10, 12);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "🔍  Tìm kiếm cảnh báo...";
            txtSearch.SelectedText = "";
            txtSearch.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSearch.Size = new Size(280, 36);
            txtSearch.TabIndex = 1;
            // 
            // pnlTitleBar
            // 
            pnlTitleBar.BackColor = Color.Transparent;
            pnlTitleBar.Controls.Add(lblTitle);
            pnlTitleBar.Dock = DockStyle.Top;
            pnlTitleBar.Location = new Point(0, 0);
            pnlTitleBar.Name = "pnlTitleBar";
            pnlTitleBar.Size = new Size(1060, 60);
            pnlTitleBar.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Emoji", 15F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(287, 33);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🔔  Quản Lý Cảnh Báo";
            // 
            // AlertForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(1060, 660);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AlertForm";
            Text = "AlertForm";
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAlerts).EndInit();
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
        private Guna.UI2.WinForms.Guna2GradientButton btnResolve;
        private Guna.UI2.WinForms.Guna2DataGridView   dgvAlerts;
    }
}

