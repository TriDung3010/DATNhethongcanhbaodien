namespace WinformsDashboard;

partial class frmDashboard
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        pnlSidebar = new Panel();
        btnSettings = new Button();
        btnHistory = new Button();
        btnDashboard = new Button();
        lblSidebarTitle = new Label();
        pnlContent = new Panel();
        tlpMain = new TableLayoutPanel();
        pnlHeader = new Panel();
        lblTitle = new Label();
        lblSubtitle = new Label();
        lblOnlineStatus = new Label();
        flpCards = new FlowLayoutPanel();
        pnlStatusCard = new Panel();
        lblCardStatusTitle = new Label();
        lblStatus = new Label();
        pnlStatusDot = new Panel();
        pnlCurrentCard = new Panel();
        lblCardCurrentTitle = new Label();
        lblCurrent = new Label();
        lblCurrentUnit = new Label();
        pnlPacketCard = new Panel();
        lblCardPacketTitle = new Label();
        lblPacketCount = new Label();
        lblPacketLabel = new Label();
        pnlChartContainer = new Panel();
        lblChartTitle = new Label();
        chartView = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
        pnlHistoryContainer = new Panel();
        lblHistoryTitle = new Label();
        dgvHistory = new DataGridView();
        pnlFooter = new Panel();
        lblLog = new Label();
        pnlSidebar.SuspendLayout();
        pnlContent.SuspendLayout();
        tlpMain.SuspendLayout();
        pnlHeader.SuspendLayout();
        flpCards.SuspendLayout();
        pnlStatusCard.SuspendLayout();
        pnlCurrentCard.SuspendLayout();
        pnlPacketCard.SuspendLayout();
        pnlChartContainer.SuspendLayout();
        pnlHistoryContainer.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
        pnlFooter.SuspendLayout();
        SuspendLayout();
        // 
        // pnlSidebar
        // 
        pnlSidebar.BackColor = Color.FromArgb(22, 27, 34);
        pnlSidebar.Controls.Add(btnSettings);
        pnlSidebar.Controls.Add(btnHistory);
        pnlSidebar.Controls.Add(btnDashboard);
        pnlSidebar.Controls.Add(lblSidebarTitle);
        pnlSidebar.Dock = DockStyle.Left;
        pnlSidebar.Location = new Point(0, 0);
        pnlSidebar.Name = "pnlSidebar";
        pnlSidebar.Size = new Size(200, 680);
        pnlSidebar.TabIndex = 0;
        // 
        // btnSettings
        // 
        btnSettings.Dock = DockStyle.Top;
        btnSettings.FlatAppearance.BorderSize = 0;
        btnSettings.FlatStyle = FlatStyle.Flat;
        btnSettings.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnSettings.ForeColor = Color.White;
        btnSettings.Location = new Point(0, 160);
        btnSettings.Name = "btnSettings";
        btnSettings.Padding = new Padding(20, 0, 0, 0);
        btnSettings.Size = new Size(200, 45);
        btnSettings.TabIndex = 3;
        btnSettings.Text = "⚙  Cài đặt";
        btnSettings.TextAlign = ContentAlignment.MiddleLeft;
        btnSettings.UseVisualStyleBackColor = true;
        // 
        // btnHistory
        // 
        btnHistory.Dock = DockStyle.Top;
        btnHistory.FlatAppearance.BorderSize = 0;
        btnHistory.FlatStyle = FlatStyle.Flat;
        btnHistory.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
        btnHistory.ForeColor = Color.White;
        btnHistory.Location = new Point(0, 115);
        btnHistory.Name = "btnHistory";
        btnHistory.Padding = new Padding(20, 0, 0, 0);
        btnHistory.Size = new Size(200, 45);
        btnHistory.TabIndex = 2;
        btnHistory.Text = "🕒 Lịch sử";
        btnHistory.TextAlign = ContentAlignment.MiddleLeft;
        btnHistory.UseVisualStyleBackColor = true;
        // 
        // btnDashboard
        // 
        btnDashboard.BackColor = Color.FromArgb(46, 160, 67);
        btnDashboard.Dock = DockStyle.Top;
        btnDashboard.FlatAppearance.BorderSize = 0;
        btnDashboard.FlatStyle = FlatStyle.Flat;
        btnDashboard.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
        btnDashboard.ForeColor = Color.White;
        btnDashboard.Location = new Point(0, 70);
        btnDashboard.Name = "btnDashboard";
        btnDashboard.Padding = new Padding(20, 0, 0, 0);
        btnDashboard.Size = new Size(200, 45);
        btnDashboard.TabIndex = 1;
        btnDashboard.Text = "📊 Tổng quan";
        btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
        btnDashboard.UseVisualStyleBackColor = false;
        // 
        // lblSidebarTitle
        // 
        lblSidebarTitle.Dock = DockStyle.Top;
        lblSidebarTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblSidebarTitle.ForeColor = Color.White;
        lblSidebarTitle.Location = new Point(0, 0);
        lblSidebarTitle.Name = "lblSidebarTitle";
        lblSidebarTitle.Size = new Size(200, 70);
        lblSidebarTitle.TabIndex = 0;
        lblSidebarTitle.Text = "🔌 LEAK GUARD";
        lblSidebarTitle.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlContent
        // 
        pnlContent.Controls.Add(tlpMain);
        pnlContent.Dock = DockStyle.Fill;
        pnlContent.Location = new Point(200, 0);
        pnlContent.Name = "pnlContent";
        pnlContent.Size = new Size(720, 680);
        pnlContent.TabIndex = 1;
        // 
        // tlpMain
        // 
        tlpMain.ColumnCount = 1;
        tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpMain.Controls.Add(pnlHeader, 0, 0);
        tlpMain.Controls.Add(flpCards, 0, 1);
        tlpMain.Controls.Add(pnlChartContainer, 0, 2);
        tlpMain.Controls.Add(pnlHistoryContainer, 0, 3);
        tlpMain.Controls.Add(pnlFooter, 0, 4);
        tlpMain.Dock = DockStyle.Fill;
        tlpMain.Location = new Point(0, 0);
        tlpMain.Name = "tlpMain";
        tlpMain.RowCount = 5;
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 78F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 95F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 55F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 45F));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
        tlpMain.Size = new Size(720, 680);
        tlpMain.TabIndex = 0;
        // 
        // pnlHeader
        // 
        pnlHeader.BackColor = Color.White;
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(lblSubtitle);
        pnlHeader.Controls.Add(lblOnlineStatus);
        pnlHeader.Dock = DockStyle.Fill;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Margin = new Padding(0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(720, 78);
        pnlHeader.TabIndex = 0;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTitle.ForeColor = Color.FromArgb(22, 27, 34);
        lblTitle.Location = new Point(20, 14);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(278, 30);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "Hệ thống Giám sát Dòng rò";
        // 
        // lblSubtitle
        // 
        lblSubtitle.AutoSize = true;
        lblSubtitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblSubtitle.ForeColor = Color.FromArgb(100, 110, 120);
        lblSubtitle.Location = new Point(24, 46);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(244, 15);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Dashboard giám sát & cảnh báo rò rỉ điện năng";
        // 
        // lblOnlineStatus
        // 
        lblOnlineStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblOnlineStatus.AutoSize = true;
        lblOnlineStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblOnlineStatus.ForeColor = Color.FromArgb(46, 160, 67);
        lblOnlineStatus.Location = new Point(600, 46);
        lblOnlineStatus.Name = "lblOnlineStatus";
        lblOnlineStatus.Size = new Size(95, 15);
        lblOnlineStatus.TabIndex = 2;
        lblOnlineStatus.Text = "● Đang hoạt động";
        // 
        // flpCards
        // 
        flpCards.BackColor = Color.FromArgb(240, 242, 245);
        flpCards.Controls.Add(pnlStatusCard);
        flpCards.Controls.Add(pnlCurrentCard);
        flpCards.Controls.Add(pnlPacketCard);
        flpCards.Dock = DockStyle.Fill;
        flpCards.Location = new Point(0, 78);
        flpCards.Margin = new Padding(0);
        flpCards.Name = "flpCards";
        flpCards.Padding = new Padding(12, 10, 12, 10);
        flpCards.Size = new Size(720, 95);
        flpCards.TabIndex = 1;
        flpCards.WrapContents = false;
        // 
        // pnlStatusCard
        // 
        pnlStatusCard.BackColor = Color.White;
        pnlStatusCard.Controls.Add(lblCardStatusTitle);
        pnlStatusCard.Controls.Add(lblStatus);
        pnlStatusCard.Controls.Add(pnlStatusDot);
        pnlStatusCard.Location = new Point(12, 10);
        pnlStatusCard.Margin = new Padding(0, 0, 12, 0);
        pnlStatusCard.Name = "pnlStatusCard";
        pnlStatusCard.Size = new Size(220, 72);
        pnlStatusCard.TabIndex = 0;
        // 
        // lblCardStatusTitle
        // 
        lblCardStatusTitle.AutoSize = true;
        lblCardStatusTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCardStatusTitle.ForeColor = Color.FromArgb(100, 110, 120);
        lblCardStatusTitle.Location = new Point(14, 8);
        lblCardStatusTitle.Name = "lblCardStatusTitle";
        lblCardStatusTitle.Size = new Size(69, 13);
        lblCardStatusTitle.TabIndex = 0;
        lblCardStatusTitle.Text = "TRẠNG THÁI";
        // 
        // lblStatus
        // 
        lblStatus.AutoSize = true;
        lblStatus.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblStatus.ForeColor = Color.FromArgb(46, 160, 67);
        lblStatus.Location = new Point(38, 30);
        lblStatus.Name = "lblStatus";
        lblStatus.Size = new Size(160, 30);
        lblStatus.TabIndex = 1;
        lblStatus.Text = "BÌNH THƯỜNG";
        // 
        // pnlStatusDot
        // 
        pnlStatusDot.BackColor = Color.FromArgb(46, 160, 67);
        pnlStatusDot.Location = new Point(14, 38);
        pnlStatusDot.Name = "pnlStatusDot";
        pnlStatusDot.Size = new Size(16, 16);
        pnlStatusDot.TabIndex = 2;
        // 
        // pnlCurrentCard
        // 
        pnlCurrentCard.BackColor = Color.White;
        pnlCurrentCard.Controls.Add(lblCardCurrentTitle);
        pnlCurrentCard.Controls.Add(lblCurrent);
        pnlCurrentCard.Controls.Add(lblCurrentUnit);
        pnlCurrentCard.Location = new Point(244, 10);
        pnlCurrentCard.Margin = new Padding(0, 0, 12, 0);
        pnlCurrentCard.Name = "pnlCurrentCard";
        pnlCurrentCard.Size = new Size(220, 72);
        pnlCurrentCard.TabIndex = 1;
        // 
        // lblCardCurrentTitle
        // 
        lblCardCurrentTitle.AutoSize = true;
        lblCardCurrentTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCardCurrentTitle.ForeColor = Color.FromArgb(100, 110, 120);
        lblCardCurrentTitle.Location = new Point(14, 8);
        lblCardCurrentTitle.Name = "lblCardCurrentTitle";
        lblCardCurrentTitle.Size = new Size(106, 13);
        lblCardCurrentTitle.TabIndex = 0;
        lblCardCurrentTitle.Text = "DÒNG RÒ HIỆN TẠI";
        // 
        // lblCurrent
        // 
        lblCurrent.AutoSize = true;
        lblCurrent.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCurrent.ForeColor = Color.FromArgb(22, 27, 34);
        lblCurrent.Location = new Point(14, 20);
        lblCurrent.Name = "lblCurrent";
        lblCurrent.Size = new Size(89, 47);
        lblCurrent.TabIndex = 1;
        lblCurrent.Text = "0.00";
        // 
        // lblCurrentUnit
        // 
        lblCurrentUnit.AutoSize = true;
        lblCurrentUnit.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblCurrentUnit.ForeColor = Color.FromArgb(100, 110, 120);
        lblCurrentUnit.Location = new Point(110, 38);
        lblCurrentUnit.Name = "lblCurrentUnit";
        lblCurrentUnit.Size = new Size(39, 25);
        lblCurrentUnit.TabIndex = 2;
        lblCurrentUnit.Text = "mA";
        // 
        // pnlPacketCard
        // 
        pnlPacketCard.BackColor = Color.White;
        pnlPacketCard.Controls.Add(lblCardPacketTitle);
        pnlPacketCard.Controls.Add(lblPacketCount);
        pnlPacketCard.Controls.Add(lblPacketLabel);
        pnlPacketCard.Location = new Point(476, 10);
        pnlPacketCard.Margin = new Padding(0);
        pnlPacketCard.Name = "pnlPacketCard";
        pnlPacketCard.Size = new Size(220, 72);
        pnlPacketCard.TabIndex = 2;
        // 
        // lblCardPacketTitle
        // 
        lblCardPacketTitle.AutoSize = true;
        lblCardPacketTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblCardPacketTitle.ForeColor = Color.FromArgb(100, 110, 120);
        lblCardPacketTitle.Location = new Point(14, 8);
        lblCardPacketTitle.Name = "lblCardPacketTitle";
        lblCardPacketTitle.Size = new Size(88, 13);
        lblCardPacketTitle.TabIndex = 0;
        lblCardPacketTitle.Text = "GÓI TIN ĐÃ NHẬN";
        // 
        // lblPacketCount
        // 
        lblPacketCount.AutoSize = true;
        lblPacketCount.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblPacketCount.ForeColor = Color.FromArgb(22, 27, 34);
        lblPacketCount.Location = new Point(14, 20);
        lblPacketCount.Name = "lblPacketCount";
        lblPacketCount.Size = new Size(40, 47);
        lblPacketCount.TabIndex = 1;
        lblPacketCount.Text = "0";
        // 
        // lblPacketLabel
        // 
        lblPacketLabel.AutoSize = true;
        lblPacketLabel.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblPacketLabel.ForeColor = Color.FromArgb(100, 110, 120);
        lblPacketLabel.Location = new Point(80, 38);
        lblPacketLabel.Name = "lblPacketLabel";
        lblPacketLabel.Size = new Size(38, 25);
        lblPacketLabel.TabIndex = 2;
        lblPacketLabel.Text = "gói";
        // 
        // pnlChartContainer
        // 
        pnlChartContainer.BackColor = Color.White;
        pnlChartContainer.Controls.Add(lblChartTitle);
        pnlChartContainer.Controls.Add(chartView);
        pnlChartContainer.Dock = DockStyle.Fill;
        pnlChartContainer.Location = new Point(12, 173);
        pnlChartContainer.Margin = new Padding(12, 0, 12, 4);
        pnlChartContainer.Name = "pnlChartContainer";
        pnlChartContainer.Padding = new Padding(12, 10, 12, 10);
        pnlChartContainer.Size = new Size(696, 259);
        pnlChartContainer.TabIndex = 2;
        // 
        // lblChartTitle
        // 
        lblChartTitle.AutoSize = true;
        lblChartTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblChartTitle.ForeColor = Color.FromArgb(100, 110, 120);
        lblChartTitle.Location = new Point(14, 10);
        lblChartTitle.Name = "lblChartTitle";
        lblChartTitle.Size = new Size(149, 15);
        lblChartTitle.TabIndex = 0;
        lblChartTitle.Text = "BIỂU ĐỒ DÒNG RÒ REALTIME";
        // 
        // chartView
        // 
        chartView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        chartView.Location = new Point(12, 35);
        chartView.Margin = new Padding(0);
        chartView.Name = "chartView";
        chartView.Size = new Size(672, 214);
        chartView.TabIndex = 1;
        // 
        // pnlHistoryContainer
        // 
        pnlHistoryContainer.BackColor = Color.White;
        pnlHistoryContainer.Controls.Add(lblHistoryTitle);
        pnlHistoryContainer.Controls.Add(dgvHistory);
        pnlHistoryContainer.Dock = DockStyle.Fill;
        pnlHistoryContainer.Location = new Point(12, 436);
        pnlHistoryContainer.Margin = new Padding(12, 0, 12, 8);
        pnlHistoryContainer.Name = "pnlHistoryContainer";
        pnlHistoryContainer.Padding = new Padding(12, 10, 12, 10);
        pnlHistoryContainer.Size = new Size(696, 207);
        pnlHistoryContainer.TabIndex = 3;
        // 
        // lblHistoryTitle
        // 
        lblHistoryTitle.AutoSize = true;
        lblHistoryTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblHistoryTitle.ForeColor = Color.FromArgb(100, 110, 120);
        lblHistoryTitle.Location = new Point(14, 10);
        lblHistoryTitle.Name = "lblHistoryTitle";
        lblHistoryTitle.Size = new Size(130, 15);
        lblHistoryTitle.TabIndex = 0;
        lblHistoryTitle.Text = "LỊCH SỬ 50 BẢN GHI";
        // 
        // dgvHistory
        // 
        dgvHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvHistory.BackgroundColor = Color.White;
        dgvHistory.BorderStyle = BorderStyle.None;
        dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgvHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvHistory.Location = new Point(12, 35);
        dgvHistory.Margin = new Padding(0);
        dgvHistory.Name = "dgvHistory";
        dgvHistory.ReadOnly = true;
        dgvHistory.RowHeadersVisible = false;
        dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvHistory.Size = new Size(672, 162);
        dgvHistory.TabIndex = 1;
        dgvHistory.EnableHeadersVisualStyles = false;
        dgvHistory.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Color.FromArgb(240, 242, 245),
            ForeColor = Color.FromArgb(60, 70, 80),
            Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0),
            SelectionBackColor = Color.FromArgb(240, 242, 245)
        };
        dgvHistory.DefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Color.White,
            ForeColor = Color.FromArgb(50, 50, 50),
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0),
            SelectionBackColor = Color.FromArgb(200, 220, 245),
            SelectionForeColor = Color.FromArgb(22, 27, 34)
        };
        dgvHistory.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Color.FromArgb(247, 248, 250)
        };
        dgvHistory.GridColor = Color.FromArgb(230, 232, 235);
        // 
        // pnlFooter
        // 
        pnlFooter.BackColor = Color.FromArgb(22, 27, 34);
        pnlFooter.Controls.Add(lblLog);
        pnlFooter.Dock = DockStyle.Fill;
        pnlFooter.Location = new Point(0, 651);
        pnlFooter.Margin = new Padding(0);
        pnlFooter.Name = "pnlFooter";
        pnlFooter.Size = new Size(720, 29);
        pnlFooter.TabIndex = 4;
        // 
        // lblLog
        // 
        lblLog.Dock = DockStyle.Fill;
        lblLog.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
        lblLog.ForeColor = Color.FromArgb(139, 157, 187);
        lblLog.Location = new Point(0, 0);
        lblLog.Name = "lblLog";
        lblLog.Padding = new Padding(12, 0, 0, 0);
        lblLog.Size = new Size(720, 29);
        lblLog.TabIndex = 0;
        lblLog.Text = "⏳ Đang khởi động server...";
        lblLog.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // frmDashboard
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(240, 242, 245);
        ClientSize = new Size(920, 680);
        Controls.Add(pnlContent);
        Controls.Add(pnlSidebar);
        MinimumSize = new Size(800, 600);
        Name = "frmDashboard";
        Text = "Hệ thống Cảnh báo Rò rỉ Điện năng - Dashboard";
        Load += frmDashboard_Load;
        FormClosing += frmDashboard_FormClosing;
        pnlSidebar.ResumeLayout(false);
        pnlContent.ResumeLayout(false);
        tlpMain.ResumeLayout(false);
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        flpCards.ResumeLayout(false);
        pnlStatusCard.ResumeLayout(false);
        pnlStatusCard.PerformLayout();
        pnlCurrentCard.ResumeLayout(false);
        pnlCurrentCard.PerformLayout();
        pnlPacketCard.ResumeLayout(false);
        pnlPacketCard.PerformLayout();
        pnlChartContainer.ResumeLayout(false);
        pnlChartContainer.PerformLayout();
        pnlHistoryContainer.ResumeLayout(false);
        pnlHistoryContainer.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
        pnlFooter.ResumeLayout(false);
        ResumeLayout(false);
    }

    private Panel pnlSidebar;
    private Button btnSettings;
    private Button btnHistory;
    private Button btnDashboard;
    private Label lblSidebarTitle;
    private Panel pnlContent;
    private TableLayoutPanel tlpMain;
    private Panel pnlHeader;
    private Label lblTitle;
    private Label lblSubtitle;
    private Label lblOnlineStatus;
    private FlowLayoutPanel flpCards;
    private Panel pnlStatusCard;
    private Label lblCardStatusTitle;
    private Label lblStatus;
    private Panel pnlStatusDot;
    private Panel pnlCurrentCard;
    private Label lblCardCurrentTitle;
    private Label lblCurrent;
    private Label lblCurrentUnit;
    private Panel pnlPacketCard;
    private Label lblCardPacketTitle;
    private Label lblPacketCount;
    private Label lblPacketLabel;
    private Panel pnlChartContainer;
    private Label lblChartTitle;
    private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chartView;
    private Panel pnlHistoryContainer;
    private Label lblHistoryTitle;
    private DataGridView dgvHistory;
    private Panel pnlFooter;
    private Label lblLog;
}
