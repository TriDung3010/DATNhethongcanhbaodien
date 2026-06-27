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

        // tlpMain
        tlpMain.ColumnCount = 1;
        tlpMain.Dock = DockStyle.Fill;
        tlpMain.Location = new Point(0, 0);
        tlpMain.Name = "tlpMain";
        tlpMain.Padding = new Padding(0);
        tlpMain.RowCount = 5;
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 78));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 95));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 55));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 45));
        tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 28));
        tlpMain.TabIndex = 0;

        // pnlHeader
        pnlHeader.BackColor = Color.FromArgb(22, 27, 34);
        pnlHeader.Controls.Add(lblTitle);
        pnlHeader.Controls.Add(lblSubtitle);
        pnlHeader.Controls.Add(lblOnlineStatus);
        pnlHeader.Dock = DockStyle.Fill;
        pnlHeader.Name = "pnlHeader";

        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(20, 14);
        lblTitle.Text = "\u26a1 H\u1ec7 th\u1ed1ng C\u1ea3nh b\u00e1o R\u00f2 r\u1ec9 \u0110i\u1ec7n";
        lblTitle.Name = "lblTitle";

        lblSubtitle.AutoSize = true;
        lblSubtitle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
        lblSubtitle.ForeColor = Color.FromArgb(139, 157, 187);
        lblSubtitle.Location = new Point(24, 46);
        lblSubtitle.Text = "Dashboard gi\u00e1m s\u00e1t & c\u1ea3nh b\u00e1o r\u00f2 r\u1ec9 \u0111i\u1ec7n n\u0103ng";
        lblSubtitle.Name = "lblSubtitle";

        lblOnlineStatus.AutoSize = true;
        lblOnlineStatus.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        lblOnlineStatus.ForeColor = Color.FromArgb(46, 160, 67);
        lblOnlineStatus.Location = new Point(750, 46);
        lblOnlineStatus.Text = "\u25cf \u0110ang ho\u1ea1t \u0111\u1ed9ng";
        lblOnlineStatus.Name = "lblOnlineStatus";

        // flpCards
        flpCards.BackColor = Color.FromArgb(240, 242, 245);
        flpCards.Controls.Add(pnlStatusCard);
        flpCards.Controls.Add(pnlCurrentCard);
        flpCards.Controls.Add(pnlPacketCard);
        flpCards.Dock = DockStyle.Fill;
        flpCards.Location = new Point(0, 78);
        flpCards.Margin = new Padding(0);
        flpCards.Name = "flpCards";
        flpCards.Padding = new Padding(12, 10, 12, 10);
        flpCards.WrapContents = false;

        // pnlStatusCard
        pnlStatusCard.BackColor = Color.White;
        pnlStatusCard.Controls.Add(lblCardStatusTitle);
        pnlStatusCard.Controls.Add(lblStatus);
        pnlStatusCard.Controls.Add(pnlStatusDot);
        pnlStatusCard.Margin = new Padding(0, 0, 12, 0);
        pnlStatusCard.Name = "pnlStatusCard";
        pnlStatusCard.Size = new Size(270, 72);

        lblCardStatusTitle.AutoSize = true;
        lblCardStatusTitle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
        lblCardStatusTitle.ForeColor = Color.FromArgb(100, 110, 120);
        lblCardStatusTitle.Location = new Point(14, 8);
        lblCardStatusTitle.Text = "TR\u1ea0NG TH\u00c1I";
        lblCardStatusTitle.Name = "lblCardStatusTitle";

        lblStatus.AutoSize = true;
        lblStatus.Font = new Font("Segoe UI", 16, FontStyle.Bold);
        lblStatus.ForeColor = Color.FromArgb(46, 160, 67);
        lblStatus.Location = new Point(38, 30);
        lblStatus.Text = "B\u00ccNH TH\u01af\u1edcNG";
        lblStatus.Name = "lblStatus";

        pnlStatusDot.BackColor = Color.FromArgb(46, 160, 67);
        pnlStatusDot.Location = new Point(14, 38);
        pnlStatusDot.Name = "pnlStatusDot";
        pnlStatusDot.Size = new Size(16, 16);

        // pnlCurrentCard
        pnlCurrentCard.BackColor = Color.White;
        pnlCurrentCard.Controls.Add(lblCardCurrentTitle);
        pnlCurrentCard.Controls.Add(lblCurrent);
        pnlCurrentCard.Controls.Add(lblCurrentUnit);
        pnlCurrentCard.Margin = new Padding(0, 0, 12, 0);
        pnlCurrentCard.Name = "pnlCurrentCard";
        pnlCurrentCard.Size = new Size(270, 72);

        lblCardCurrentTitle.AutoSize = true;
        lblCardCurrentTitle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
        lblCardCurrentTitle.ForeColor = Color.FromArgb(100, 110, 120);
        lblCardCurrentTitle.Location = new Point(14, 8);
        lblCardCurrentTitle.Text = "D\u00d2NG R\u00d2 HI\u1ec6N T\u1ea0I";
        lblCardCurrentTitle.Name = "lblCardCurrentTitle";

        lblCurrent.AutoSize = true;
        lblCurrent.Font = new Font("Segoe UI", 26, FontStyle.Bold);
        lblCurrent.ForeColor = Color.FromArgb(22, 27, 34);
        lblCurrent.Location = new Point(14, 26);
        lblCurrent.Text = "0.00";
        lblCurrent.Name = "lblCurrent";

        lblCurrentUnit.AutoSize = true;
        lblCurrentUnit.Font = new Font("Segoe UI", 14, FontStyle.Regular);
        lblCurrentUnit.ForeColor = Color.FromArgb(100, 110, 120);
        lblCurrentUnit.Location = new Point(110, 38);
        lblCurrentUnit.Text = "mA";
        lblCurrentUnit.Name = "lblCurrentUnit";

        // pnlPacketCard
        pnlPacketCard.BackColor = Color.White;
        pnlPacketCard.Controls.Add(lblCardPacketTitle);
        pnlPacketCard.Controls.Add(lblPacketCount);
        pnlPacketCard.Controls.Add(lblPacketLabel);
        pnlPacketCard.Margin = new Padding(0);
        pnlPacketCard.Name = "pnlPacketCard";
        pnlPacketCard.Size = new Size(270, 72);

        lblCardPacketTitle.AutoSize = true;
        lblCardPacketTitle.Font = new Font("Segoe UI", 8, FontStyle.Bold);
        lblCardPacketTitle.ForeColor = Color.FromArgb(100, 110, 120);
        lblCardPacketTitle.Location = new Point(14, 8);
        lblCardPacketTitle.Text = "G\u00d3I TIN \u0110\u00c3 NH\u1eacN";
        lblCardPacketTitle.Name = "lblCardPacketTitle";

        lblPacketCount.AutoSize = true;
        lblPacketCount.Font = new Font("Segoe UI", 26, FontStyle.Bold);
        lblPacketCount.ForeColor = Color.FromArgb(22, 27, 34);
        lblPacketCount.Location = new Point(14, 26);
        lblPacketCount.Text = "0";
        lblPacketCount.Name = "lblPacketCount";

        lblPacketLabel.AutoSize = true;
        lblPacketLabel.Font = new Font("Segoe UI", 14, FontStyle.Regular);
        lblPacketLabel.ForeColor = Color.FromArgb(100, 110, 120);
        lblPacketLabel.Location = new Point(50, 38);
        lblPacketLabel.Text = "g\u00f3i";
        lblPacketLabel.Name = "lblPacketLabel";

        // pnlChartContainer
        pnlChartContainer.BackColor = Color.White;
        pnlChartContainer.Controls.Add(lblChartTitle);
        pnlChartContainer.Controls.Add(chartView);
        pnlChartContainer.Dock = DockStyle.Fill;
        pnlChartContainer.Margin = new Padding(12, 0, 12, 4);
        pnlChartContainer.Name = "pnlChartContainer";
        pnlChartContainer.Padding = new Padding(12, 10, 12, 10);

        lblChartTitle.AutoSize = true;
        lblChartTitle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        lblChartTitle.ForeColor = Color.FromArgb(100, 110, 120);
        lblChartTitle.Location = new Point(14, 10);
        lblChartTitle.Text = "BI\u1ec2U \u0110\u1ed2 D\u00d2NG R\u00d2 REALTIME";
        lblChartTitle.Name = "lblChartTitle";

        chartView.Dock = DockStyle.Fill;
        chartView.Location = new Point(12, 10);
        chartView.Margin = new Padding(0, 22, 0, 0);
        chartView.Name = "chartView";

        // pnlHistoryContainer
        pnlHistoryContainer.BackColor = Color.White;
        pnlHistoryContainer.Controls.Add(lblHistoryTitle);
        pnlHistoryContainer.Controls.Add(dgvHistory);
        pnlHistoryContainer.Dock = DockStyle.Fill;
        pnlHistoryContainer.Margin = new Padding(12, 0, 12, 8);
        pnlHistoryContainer.Name = "pnlHistoryContainer";
        pnlHistoryContainer.Padding = new Padding(12, 10, 12, 10);

        lblHistoryTitle.AutoSize = true;
        lblHistoryTitle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        lblHistoryTitle.ForeColor = Color.FromArgb(100, 110, 120);
        lblHistoryTitle.Location = new Point(14, 10);
        lblHistoryTitle.Text = "L\u1ecaCH S\u1eec 50 B\u1ea2N GHI";
        lblHistoryTitle.Name = "lblHistoryTitle";

        dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvHistory.BackgroundColor = Color.White;
        dgvHistory.BorderStyle = BorderStyle.None;
        dgvHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dgvHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvHistory.Dock = DockStyle.Fill;
        dgvHistory.Location = new Point(12, 10);
        dgvHistory.Margin = new Padding(0, 22, 0, 0);
        dgvHistory.Name = "dgvHistory";
        dgvHistory.ReadOnly = true;
        dgvHistory.RowHeadersVisible = false;
        dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvHistory.EnableHeadersVisualStyles = false;
        dgvHistory.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Color.FromArgb(240, 242, 245),
            ForeColor = Color.FromArgb(60, 70, 80),
            Font = new Font("Segoe UI", 8, FontStyle.Bold),
            SelectionBackColor = Color.FromArgb(240, 242, 245)
        };
        dgvHistory.DefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Color.White,
            ForeColor = Color.FromArgb(50, 50, 50),
            Font = new Font("Segoe UI", 9, FontStyle.Regular),
            SelectionBackColor = Color.FromArgb(200, 220, 245),
            SelectionForeColor = Color.FromArgb(22, 27, 34)
        };
        dgvHistory.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
        {
            BackColor = Color.FromArgb(247, 248, 250)
        };
        dgvHistory.GridColor = Color.FromArgb(230, 232, 235);
        dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

        // pnlFooter
        pnlFooter.BackColor = Color.FromArgb(22, 27, 34);
        pnlFooter.Controls.Add(lblLog);
        pnlFooter.Dock = DockStyle.Fill;
        pnlFooter.Name = "pnlFooter";

        lblLog.Dock = DockStyle.Fill;
        lblLog.Font = new Font("Segoe UI", 8, FontStyle.Regular);
        lblLog.ForeColor = Color.FromArgb(139, 157, 187);
        lblLog.Location = new Point(0, 0);
        lblLog.Name = "lblLog";
        lblLog.Padding = new Padding(12, 0, 0, 0);
        lblLog.TextAlign = ContentAlignment.MiddleLeft;
        lblLog.Text = "\u23f3 \u0110ang kh\u1edfi \u0111\u1ed9ng server...";

        // frmDashboard
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(240, 242, 245);
        ClientSize = new Size(920, 680);
        Controls.Add(tlpMain);
        Name = "frmDashboard";
        Text = "H\u1ec7 th\u1ed1ng C\u1ea3nh b\u00e1o R\u00f2 r\u1ec9 \u0110i\u1ec7n n\u0103ng";
        MinimumSize = new Size(800, 600);
        Load += frmDashboard_Load;
        FormClosing += frmDashboard_FormClosing;

        // TableLayoutPanel rows
        tlpMain.Controls.Add(pnlHeader, 0, 0);
        tlpMain.Controls.Add(flpCards, 0, 1);
        tlpMain.Controls.Add(pnlChartContainer, 0, 2);
        tlpMain.Controls.Add(pnlHistoryContainer, 0, 3);
        tlpMain.Controls.Add(pnlFooter, 0, 4);

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
