namespace WinformsDashboard
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.btnRoomManager = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(27)))), ((int)(((byte)(34)))));
            this.pnlSidebar.Controls.Add(this.btnRoomManager);
            this.pnlSidebar.Controls.Add(this.btnHistory);
            this.pnlSidebar.Controls.Add(this.btnDashboard);
            this.pnlSidebar.Controls.Add(this.lblSidebarTitle);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(200, 680);
            this.pnlSidebar.TabIndex = 0;
            // 
            // btnRoomManager
            // 
            this.btnRoomManager.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRoomManager.FlatAppearance.BorderSize = 0;
            this.btnRoomManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoomManager.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRoomManager.ForeColor = System.Drawing.Color.White;
            this.btnRoomManager.Location = new System.Drawing.Point(0, 160);
            this.btnRoomManager.Name = "btnRoomManager";
            this.btnRoomManager.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnRoomManager.Size = new System.Drawing.Size(200, 45);
            this.btnRoomManager.TabIndex = 3;
            this.btnRoomManager.Text = "⚙  Quản lý phòng";
            this.btnRoomManager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoomManager.UseVisualStyleBackColor = true;
            this.btnRoomManager.Click += new System.EventHandler(this.btnRoomManager_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHistory.FlatAppearance.BorderSize = 0;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnHistory.ForeColor = System.Drawing.Color.White;
            this.btnHistory.Location = new System.Drawing.Point(0, 115);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnHistory.Size = new System.Drawing.Size(200, 45);
            this.btnHistory.TabIndex = 2;
            this.btnHistory.Text = "🕒 Lịch sử";
            this.btnHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(160)))), ((int)(((byte)(67)))));
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDashboard.ForeColor = System.Drawing.Color.White;
            this.btnDashboard.Location = new System.Drawing.Point(0, 70);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(200, 45);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Text = "📊 Tổng quan";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.btnDashboard_Click);
            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.White;
            this.lblSidebarTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Size = new System.Drawing.Size(200, 70);
            this.lblSidebarTitle.TabIndex = 0;
            this.lblSidebarTitle.Text = "🔌 LEAK GUARD";
            this.lblSidebarTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlContent
            // 
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(200, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(720, 680);
            this.pnlContent.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 680);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSidebar);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Cảnh báo Rò rỉ Điện năng - Multi-Zone";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlSidebar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Button btnRoomManager;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Label lblSidebarTitle;
        private System.Windows.Forms.Panel pnlContent;
    }
}
