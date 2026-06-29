namespace WinformsDashboard.Forms
{
    partial class HistoryForm
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
            dgvHistory = new Guna.UI2.WinForms.Guna2DataGridView();
            pnlToolbar = new Panel();
            btnExport = new Guna.UI2.WinForms.Guna2GradientButton();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            pnlTitleBar = new Panel();
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            pnlToolbar.SuspendLayout();
            pnlTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(240, 242, 245);
            pnlMain.Controls.Add(dgvHistory);
            pnlMain.Controls.Add(pnlToolbar);
            pnlMain.Controls.Add(pnlTitleBar);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1060, 660);
            pnlMain.TabIndex = 0;
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(222, 226, 230);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dgvHistory.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvHistory.BackgroundColor = Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(240, 242, 245);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvHistory.ColumnHeadersHeight = 44;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(222, 226, 230);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvHistory.DefaultCellStyle = dataGridViewCellStyle3;
            dgvHistory.Dock = DockStyle.Fill;
            dgvHistory.GridColor = Color.FromArgb(222, 226, 230);
            dgvHistory.Location = new Point(0, 120);
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.RowHeadersWidth = 51;
            dgvHistory.RowTemplate.Height = 38;
            dgvHistory.Size = new Size(1060, 540);
            dgvHistory.TabIndex = 0;
            dgvHistory.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgvHistory.ThemeStyle.AlternatingRowsStyle.Font = new Font("Segoe UI", 10F);
            dgvHistory.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvHistory.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.FromArgb(222, 226, 230);
            dgvHistory.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.FromArgb(33, 37, 41);
            dgvHistory.ThemeStyle.BackColor = Color.FromArgb(240, 242, 245);
            dgvHistory.ThemeStyle.GridColor = Color.FromArgb(222, 226, 230);
            dgvHistory.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(240, 242, 245);
            dgvHistory.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvHistory.ThemeStyle.HeaderStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvHistory.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHistory.ThemeStyle.HeaderStyle.Height = 44;
            dgvHistory.ThemeStyle.ReadOnly = true;
            dgvHistory.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(255, 255, 255);
            dgvHistory.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10F);
            dgvHistory.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgvHistory.ThemeStyle.RowsStyle.Height = 38;
            dgvHistory.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(222, 226, 230);
            dgvHistory.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(33, 37, 41);
            // 
            // pnlToolbar
            // 
            pnlToolbar.BackColor = Color.FromArgb(255, 255, 255);
            pnlToolbar.Controls.Add(btnExport);
            pnlToolbar.Controls.Add(txtSearch);
            pnlToolbar.Dock = DockStyle.Top;
            pnlToolbar.Location = new Point(0, 60);
            pnlToolbar.Name = "pnlToolbar";
            pnlToolbar.Padding = new Padding(10, 12, 10, 12);
            pnlToolbar.Size = new Size(1060, 60);
            pnlToolbar.TabIndex = 1;
            // 
            // btnExport
            // 
            btnExport.BorderRadius = 6;
            btnExport.CustomizableEdges = customizableEdges1;
            btnExport.FillColor = Color.FromArgb(0, 120, 60);
            btnExport.FillColor2 = Color.FromArgb(0, 150, 80);
            btnExport.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Bold);
            btnExport.ForeColor = Color.White;
            btnExport.Location = new Point(310, 12);
            btnExport.Name = "btnExport";
            btnExport.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnExport.Size = new Size(144, 36);
            btnExport.TabIndex = 0;
            btnExport.Text = "📤  Xuất Excel";
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
            txtSearch.PlaceholderText = "🔍  Tìm kiếm trong lịch sử...";
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
            lblTitle.Size = new Size(373, 33);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📜  Lịch Sử Dữ Liệu Cảm Biến";
            // 
            // HistoryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(1060, 660);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "HistoryForm";
            Text = "HistoryForm";
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
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
        private Guna.UI2.WinForms.Guna2GradientButton btnExport;
        private Guna.UI2.WinForms.Guna2DataGridView   dgvHistory;
    }
}

