namespace WinformsDashboard.Forms
{
    partial class PowerLossAnalysisForm
    {
        private System.ComponentModel.IContainer components = null;

        private Guna.UI2.WinForms.Guna2Panel pnlLossCurrent;
        private System.Windows.Forms.Label lblCurrentTitle;
        private System.Windows.Forms.Label lblCurrentIcon;
        private System.Windows.Forms.Label lblTodayEnergy;
        private Guna.UI2.WinForms.Guna2Panel pnlLossEnergy;
        private System.Windows.Forms.Label lblEnergyTitle;
        private System.Windows.Forms.Label lblEnergyIcon;
        private System.Windows.Forms.Label lblTodayCost;
        private Guna.UI2.WinForms.Guna2Panel pnlLossCost;
        private System.Windows.Forms.Label lblCostTitle;
        private System.Windows.Forms.Label lblCostIcon;
        private System.Windows.Forms.Label lblMonthCost;
        private Guna.UI2.WinForms.Guna2Panel pnlLossMonthCost;
        private System.Windows.Forms.Label lblMonthCostTitle;
        private System.Windows.Forms.Label lblMonthCostIcon;

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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend skDefaultLegend1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PowerLossAnalysisForm));
            LiveChartsCore.Drawing.Padding padding1 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip skDefaultTooltip1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip();
            LiveChartsCore.Drawing.Padding padding2 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend skDefaultLegend2 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend();
            LiveChartsCore.Drawing.Padding padding3 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip skDefaultTooltip2 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip();
            LiveChartsCore.Drawing.Padding padding4 = new LiveChartsCore.Drawing.Padding();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlMain = new Panel();
            pnlGrid = new Panel();
            dgvDetails = new DataGridView();
            pnlActions = new Panel();
            btnAI = new Guna.UI2.WinForms.Guna2Button();
            btnExportExcel = new Guna.UI2.WinForms.Guna2Button();
            btnExportPdf = new Guna.UI2.WinForms.Guna2Button();
            btnConfigPrice = new Guna.UI2.WinForms.Guna2Button();
            lblAIResult = new Label();
            pnlCharts = new TableLayoutPanel();
            chartEnergy = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            chartCost = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            pnlCards = new TableLayoutPanel();
            pnlLossCurrent = new Guna.UI2.WinForms.Guna2Panel();
            lblCurrentLoss = new Label();
            lblCurrentTitle = new Label();
            lblCurrentIcon = new Label();
            pnlLossEnergy = new Guna.UI2.WinForms.Guna2Panel();
            lblTodayEnergy = new Label();
            lblEnergyTitle = new Label();
            lblEnergyIcon = new Label();
            pnlLossCost = new Guna.UI2.WinForms.Guna2Panel();
            lblTodayCost = new Label();
            lblCostTitle = new Label();
            lblCostIcon = new Label();
            pnlLossMonthCost = new Guna.UI2.WinForms.Guna2Panel();
            lblMonthCost = new Label();
            lblMonthCostTitle = new Label();
            lblMonthCostIcon = new Label();
            pnlTitleBar = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetails).BeginInit();
            pnlActions.SuspendLayout();
            pnlCharts.SuspendLayout();
            pnlCards.SuspendLayout();
            pnlLossCurrent.SuspendLayout();
            pnlLossEnergy.SuspendLayout();
            pnlLossCost.SuspendLayout();
            pnlLossMonthCost.SuspendLayout();
            pnlTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(240, 242, 245);
            pnlMain.Controls.Add(pnlGrid);
            pnlMain.Controls.Add(pnlActions);
            pnlMain.Controls.Add(pnlCharts);
            pnlMain.Controls.Add(pnlCards);
            pnlMain.Controls.Add(pnlTitleBar);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1060, 660);
            pnlMain.TabIndex = 0;
            // 
            // pnlGrid
            // 
            pnlGrid.Controls.Add(dgvDetails);
            pnlGrid.Dock = DockStyle.Fill;
            pnlGrid.Location = new Point(0, 560);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Padding = new Padding(20, 0, 20, 20);
            pnlGrid.Size = new Size(1060, 100);
            pnlGrid.TabIndex = 0;
            // 
            // dgvDetails
            // 
            dgvDetails.AllowUserToAddRows = false;
            dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetails.BackgroundColor = Color.White;
            dgvDetails.ColumnHeadersHeight = 29;
            dgvDetails.Dock = DockStyle.Fill;
            dgvDetails.Location = new Point(20, 0);
            dgvDetails.Name = "dgvDetails";
            dgvDetails.ReadOnly = true;
            dgvDetails.RowHeadersWidth = 51;
            dgvDetails.Size = new Size(1020, 80);
            dgvDetails.TabIndex = 0;
            // 
            // pnlActions
            // 
            pnlActions.Controls.Add(btnAI);
            pnlActions.Controls.Add(btnExportExcel);
            pnlActions.Controls.Add(btnExportPdf);
            pnlActions.Controls.Add(btnConfigPrice);
            pnlActions.Controls.Add(lblAIResult);
            pnlActions.Dock = DockStyle.Top;
            pnlActions.Location = new Point(0, 460);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(20, 10, 20, 10);
            pnlActions.Size = new Size(1060, 100);
            pnlActions.TabIndex = 1;
            // 
            // btnAI
            // 
            btnAI.BorderRadius = 5;
            btnAI.CustomizableEdges = customizableEdges1;
            btnAI.FillColor = Color.FromArgb(0, 120, 215);
            btnAI.Font = new Font("Segoe UI", 9F);
            btnAI.ForeColor = Color.White;
            btnAI.Location = new Point(0, 6);
            btnAI.Name = "btnAI";
            btnAI.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAI.Size = new Size(173, 40);
            btnAI.TabIndex = 0;
            btnAI.Text = "🤖 Phân tích tự động";
            btnAI.Click += btnAI_Click_1;
            // 
            // btnExportExcel
            // 
            btnExportExcel.BorderRadius = 5;
            btnExportExcel.CustomizableEdges = customizableEdges3;
            btnExportExcel.FillColor = Color.FromArgb(33, 150, 243);
            btnExportExcel.Font = new Font("Segoe UI", 9F);
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(184, 6);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnExportExcel.Size = new Size(128, 40);
            btnExportExcel.TabIndex = 1;
            btnExportExcel.Text = "📊 Xuất Excel";
            // 
            // btnExportPdf
            // 
            btnExportPdf.BorderRadius = 5;
            btnExportPdf.CustomizableEdges = customizableEdges5;
            btnExportPdf.FillColor = Color.FromArgb(244, 67, 54);
            btnExportPdf.Font = new Font("Segoe UI", 9F);
            btnExportPdf.ForeColor = Color.White;
            btnExportPdf.Location = new Point(318, 6);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnExportPdf.Size = new Size(120, 40);
            btnExportPdf.TabIndex = 2;
            btnExportPdf.Text = "📄 Xuất PDF";
            // 
            // btnConfigPrice
            // 
            btnConfigPrice.BorderRadius = 5;
            btnConfigPrice.CustomizableEdges = customizableEdges7;
            btnConfigPrice.FillColor = Color.FromArgb(96, 125, 139);
            btnConfigPrice.Font = new Font("Segoe UI", 9F);
            btnConfigPrice.ForeColor = Color.White;
            btnConfigPrice.Location = new Point(444, 6);
            btnConfigPrice.Name = "btnConfigPrice";
            btnConfigPrice.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnConfigPrice.Size = new Size(140, 40);
            btnConfigPrice.TabIndex = 3;
            btnConfigPrice.Text = "⚙ Cài Giá Điện";
            // 
            // lblAIResult
            // 
            lblAIResult.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAIResult.ForeColor = Color.FromArgb(33, 37, 41);
            lblAIResult.Location = new Point(12, 49);
            lblAIResult.Name = "lblAIResult";
            lblAIResult.Size = new Size(623, 40);
            lblAIResult.TabIndex = 4;
            lblAIResult.Text = "Nhấp 'Phân Tích AI' để đánh giá mức độ rủi ro và nhận đề xuất tiết kiệm.";
            // 
            // pnlCharts
            // 
            pnlCharts.ColumnCount = 2;
            pnlCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlCharts.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            pnlCharts.Controls.Add(chartEnergy, 0, 0);
            pnlCharts.Controls.Add(chartCost, 1, 0);
            pnlCharts.Dock = DockStyle.Top;
            pnlCharts.Location = new Point(0, 210);
            pnlCharts.Name = "pnlCharts";
            pnlCharts.Padding = new Padding(12, 0, 12, 10);
            pnlCharts.RowCount = 1;
            pnlCharts.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            pnlCharts.Size = new Size(1060, 250);
            pnlCharts.TabIndex = 2;
            // 
            // chartEnergy
            // 
            chartEnergy.AutoUpdateEnabled = true;
            chartEnergy.BackColor = Color.White;
            chartEnergy.ChartTheme = null;
            chartEnergy.Dock = DockStyle.Fill;
            skDefaultLegend1.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultLegend1.Content = null;
            skDefaultLegend1.IsValid = false;
            skDefaultLegend1.Opacity = 1F;
            padding1.Bottom = 0F;
            padding1.Left = 0F;
            padding1.Right = 0F;
            padding1.Top = 0F;
            skDefaultLegend1.Padding = padding1;
            skDefaultLegend1.RemoveOnCompleted = false;
            skDefaultLegend1.RotateTransform = 0F;
            skDefaultLegend1.X = 0F;
            skDefaultLegend1.Y = 0F;
            chartEnergy.Legend = skDefaultLegend1;
            chartEnergy.Location = new Point(22, 10);
            chartEnergy.Margin = new Padding(10);
            chartEnergy.MatchAxesScreenDataRatio = false;
            chartEnergy.Name = "chartEnergy";
            chartEnergy.Size = new Size(498, 220);
            chartEnergy.TabIndex = 0;
            skDefaultTooltip1.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultTooltip1.Content = null;
            skDefaultTooltip1.IsValid = false;
            skDefaultTooltip1.Opacity = 1F;
            padding2.Bottom = 0F;
            padding2.Left = 0F;
            padding2.Right = 0F;
            padding2.Top = 0F;
            skDefaultTooltip1.Padding = padding2;
            skDefaultTooltip1.RemoveOnCompleted = false;
            skDefaultTooltip1.RotateTransform = 0F;
            skDefaultTooltip1.Wedge = 10;
            skDefaultTooltip1.X = 0F;
            skDefaultTooltip1.Y = 0F;
            chartEnergy.Tooltip = skDefaultTooltip1;
            chartEnergy.TooltipFindingStrategy = LiveChartsCore.Measure.TooltipFindingStrategy.Automatic;
            chartEnergy.UpdaterThrottler = TimeSpan.Parse("00:00:00.0500000");
            // 
            // chartCost
            // 
            chartCost.AutoUpdateEnabled = true;
            chartCost.BackColor = Color.White;
            chartCost.ChartTheme = null;
            chartCost.Dock = DockStyle.Fill;
            skDefaultLegend2.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultLegend2.Content = null;
            skDefaultLegend2.IsValid = false;
            skDefaultLegend2.Opacity = 1F;
            padding3.Bottom = 0F;
            padding3.Left = 0F;
            padding3.Right = 0F;
            padding3.Top = 0F;
            skDefaultLegend2.Padding = padding3;
            skDefaultLegend2.RemoveOnCompleted = false;
            skDefaultLegend2.RotateTransform = 0F;
            skDefaultLegend2.X = 0F;
            skDefaultLegend2.Y = 0F;
            chartCost.Legend = skDefaultLegend2;
            chartCost.Location = new Point(540, 10);
            chartCost.Margin = new Padding(10);
            chartCost.MatchAxesScreenDataRatio = false;
            chartCost.Name = "chartCost";
            chartCost.Size = new Size(498, 220);
            chartCost.TabIndex = 1;
            skDefaultTooltip2.AnimationsSpeed = TimeSpan.Parse("00:00:00.1500000");
            skDefaultTooltip2.Content = null;
            skDefaultTooltip2.IsValid = false;
            skDefaultTooltip2.Opacity = 1F;
            padding4.Bottom = 0F;
            padding4.Left = 0F;
            padding4.Right = 0F;
            padding4.Top = 0F;
            skDefaultTooltip2.Padding = padding4;
            skDefaultTooltip2.RemoveOnCompleted = false;
            skDefaultTooltip2.RotateTransform = 0F;
            skDefaultTooltip2.Wedge = 10;
            skDefaultTooltip2.X = 0F;
            skDefaultTooltip2.Y = 0F;
            chartCost.Tooltip = skDefaultTooltip2;
            chartCost.TooltipFindingStrategy = LiveChartsCore.Measure.TooltipFindingStrategy.Automatic;
            chartCost.UpdaterThrottler = TimeSpan.Parse("00:00:00.0500000");
            // 
            // pnlCards
            // 
            pnlCards.ColumnCount = 4;
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlCards.Controls.Add(pnlLossCurrent, 0, 0);
            pnlCards.Controls.Add(pnlLossEnergy, 1, 0);
            pnlCards.Controls.Add(pnlLossCost, 2, 0);
            pnlCards.Controls.Add(pnlLossMonthCost, 3, 0);
            pnlCards.Dock = DockStyle.Top;
            pnlCards.Location = new Point(0, 70);
            pnlCards.Name = "pnlCards";
            pnlCards.Padding = new Padding(12, 0, 12, 10);
            pnlCards.RowCount = 1;
            pnlCards.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            pnlCards.Size = new Size(1060, 140);
            pnlCards.TabIndex = 3;
            // 
            // pnlLossCurrent
            // 
            pnlLossCurrent.BackColor = Color.Transparent;
            pnlLossCurrent.BorderRadius = 12;
            pnlLossCurrent.Controls.Add(lblCurrentLoss);
            pnlLossCurrent.Controls.Add(lblCurrentTitle);
            pnlLossCurrent.Controls.Add(lblCurrentIcon);
            pnlLossCurrent.CustomizableEdges = customizableEdges9;
            pnlLossCurrent.Dock = DockStyle.Fill;
            pnlLossCurrent.FillColor = Color.White;
            pnlLossCurrent.Location = new Point(18, 6);
            pnlLossCurrent.Margin = new Padding(6);
            pnlLossCurrent.Name = "pnlLossCurrent";
            pnlLossCurrent.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlLossCurrent.Size = new Size(247, 118);
            pnlLossCurrent.TabIndex = 0;
            // 
            // lblCurrentLoss
            // 
            lblCurrentLoss.BackColor = Color.Transparent;
            lblCurrentLoss.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblCurrentLoss.ForeColor = Color.FromArgb(255, 214, 0);
            lblCurrentLoss.Location = new Point(14, 65);
            lblCurrentLoss.Name = "lblCurrentLoss";
            lblCurrentLoss.Size = new Size(200, 46);
            lblCurrentLoss.TabIndex = 1;
            lblCurrentLoss.Text = "0 W";
            // 
            // lblCurrentTitle
            // 
            lblCurrentTitle.BackColor = Color.Transparent;
            lblCurrentTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblCurrentTitle.ForeColor = Color.FromArgb(120, 144, 156);
            lblCurrentTitle.Location = new Point(14, 47);
            lblCurrentTitle.Name = "lblCurrentTitle";
            lblCurrentTitle.Size = new Size(160, 18);
            lblCurrentTitle.TabIndex = 0;
            lblCurrentTitle.Text = "THẤT THOÁT HIỆN TẠI";
            // 
            // lblCurrentIcon
            // 
            lblCurrentIcon.BackColor = Color.Transparent;
            lblCurrentIcon.Font = new Font("Segoe UI Emoji", 18F);
            lblCurrentIcon.ForeColor = Color.FromArgb(255, 214, 0);
            lblCurrentIcon.Location = new Point(14, 5);
            lblCurrentIcon.Name = "lblCurrentIcon";
            lblCurrentIcon.Size = new Size(58, 40);
            lblCurrentIcon.TabIndex = 0;
            lblCurrentIcon.Text = "⚡";
            // 
            // pnlLossEnergy
            // 
            pnlLossEnergy.BackColor = Color.Transparent;
            pnlLossEnergy.BorderRadius = 12;
            pnlLossEnergy.Controls.Add(lblTodayEnergy);
            pnlLossEnergy.Controls.Add(lblEnergyTitle);
            pnlLossEnergy.Controls.Add(lblEnergyIcon);
            pnlLossEnergy.CustomizableEdges = customizableEdges11;
            pnlLossEnergy.Dock = DockStyle.Fill;
            pnlLossEnergy.FillColor = Color.White;
            pnlLossEnergy.Location = new Point(277, 6);
            pnlLossEnergy.Margin = new Padding(6);
            pnlLossEnergy.Name = "pnlLossEnergy";
            pnlLossEnergy.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlLossEnergy.Size = new Size(247, 118);
            pnlLossEnergy.TabIndex = 1;
            // 
            // lblTodayEnergy
            // 
            lblTodayEnergy.BackColor = Color.Transparent;
            lblTodayEnergy.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTodayEnergy.ForeColor = Color.FromArgb(0, 176, 255);
            lblTodayEnergy.Location = new Point(14, 65);
            lblTodayEnergy.Name = "lblTodayEnergy";
            lblTodayEnergy.Size = new Size(200, 46);
            lblTodayEnergy.TabIndex = 1;
            lblTodayEnergy.Text = "0 kWh";
            // 
            // lblEnergyTitle
            // 
            lblEnergyTitle.BackColor = Color.Transparent;
            lblEnergyTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblEnergyTitle.ForeColor = Color.FromArgb(120, 144, 156);
            lblEnergyTitle.Location = new Point(14, 47);
            lblEnergyTitle.Name = "lblEnergyTitle";
            lblEnergyTitle.Size = new Size(160, 18);
            lblEnergyTitle.TabIndex = 0;
            lblEnergyTitle.Text = "ĐIỆN NĂNG HÔM NAY";
            // 
            // lblEnergyIcon
            // 
            lblEnergyIcon.BackColor = Color.Transparent;
            lblEnergyIcon.Font = new Font("Segoe UI Emoji", 18F);
            lblEnergyIcon.ForeColor = Color.FromArgb(0, 176, 255);
            lblEnergyIcon.Location = new Point(14, 5);
            lblEnergyIcon.Name = "lblEnergyIcon";
            lblEnergyIcon.Size = new Size(58, 40);
            lblEnergyIcon.TabIndex = 0;
            lblEnergyIcon.Text = "🔋";
            // 
            // pnlLossCost
            // 
            pnlLossCost.BackColor = Color.Transparent;
            pnlLossCost.BorderRadius = 12;
            pnlLossCost.Controls.Add(lblTodayCost);
            pnlLossCost.Controls.Add(lblCostTitle);
            pnlLossCost.Controls.Add(lblCostIcon);
            pnlLossCost.CustomizableEdges = customizableEdges13;
            pnlLossCost.Dock = DockStyle.Fill;
            pnlLossCost.FillColor = Color.White;
            pnlLossCost.Location = new Point(536, 6);
            pnlLossCost.Margin = new Padding(6);
            pnlLossCost.Name = "pnlLossCost";
            pnlLossCost.ShadowDecoration.CustomizableEdges = customizableEdges14;
            pnlLossCost.Size = new Size(247, 118);
            pnlLossCost.TabIndex = 2;
            // 
            // lblTodayCost
            // 
            lblTodayCost.BackColor = Color.Transparent;
            lblTodayCost.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTodayCost.ForeColor = Color.FromArgb(255, 23, 68);
            lblTodayCost.Location = new Point(14, 65);
            lblTodayCost.Name = "lblTodayCost";
            lblTodayCost.Size = new Size(200, 46);
            lblTodayCost.TabIndex = 1;
            lblTodayCost.Text = "0 VNĐ";
            // 
            // lblCostTitle
            // 
            lblCostTitle.BackColor = Color.Transparent;
            lblCostTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblCostTitle.ForeColor = Color.FromArgb(120, 144, 156);
            lblCostTitle.Location = new Point(14, 47);
            lblCostTitle.Name = "lblCostTitle";
            lblCostTitle.Size = new Size(160, 18);
            lblCostTitle.TabIndex = 0;
            lblCostTitle.Text = "CHI PHÍ HÔM NAY";
            // 
            // lblCostIcon
            // 
            lblCostIcon.BackColor = Color.Transparent;
            lblCostIcon.Font = new Font("Segoe UI Emoji", 18F);
            lblCostIcon.ForeColor = Color.FromArgb(255, 23, 68);
            lblCostIcon.Location = new Point(14, 5);
            lblCostIcon.Name = "lblCostIcon";
            lblCostIcon.Size = new Size(58, 40);
            lblCostIcon.TabIndex = 0;
            lblCostIcon.Text = "💵";
            // 
            // pnlLossMonthCost
            // 
            pnlLossMonthCost.BackColor = Color.Transparent;
            pnlLossMonthCost.BorderRadius = 12;
            pnlLossMonthCost.Controls.Add(lblMonthCost);
            pnlLossMonthCost.Controls.Add(lblMonthCostTitle);
            pnlLossMonthCost.Controls.Add(lblMonthCostIcon);
            pnlLossMonthCost.CustomizableEdges = customizableEdges15;
            pnlLossMonthCost.Dock = DockStyle.Fill;
            pnlLossMonthCost.FillColor = Color.White;
            pnlLossMonthCost.Location = new Point(795, 6);
            pnlLossMonthCost.Margin = new Padding(6);
            pnlLossMonthCost.Name = "pnlLossMonthCost";
            pnlLossMonthCost.ShadowDecoration.CustomizableEdges = customizableEdges16;
            pnlLossMonthCost.Size = new Size(247, 118);
            pnlLossMonthCost.TabIndex = 3;
            // 
            // lblMonthCost
            // 
            lblMonthCost.BackColor = Color.Transparent;
            lblMonthCost.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblMonthCost.ForeColor = Color.FromArgb(0, 230, 118);
            lblMonthCost.Location = new Point(14, 65);
            lblMonthCost.Name = "lblMonthCost";
            lblMonthCost.Size = new Size(200, 46);
            lblMonthCost.TabIndex = 1;
            lblMonthCost.Text = "0 VNĐ";
            // 
            // lblMonthCostTitle
            // 
            lblMonthCostTitle.BackColor = Color.Transparent;
            lblMonthCostTitle.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblMonthCostTitle.ForeColor = Color.FromArgb(120, 144, 156);
            lblMonthCostTitle.Location = new Point(14, 47);
            lblMonthCostTitle.Name = "lblMonthCostTitle";
            lblMonthCostTitle.Size = new Size(160, 18);
            lblMonthCostTitle.TabIndex = 0;
            lblMonthCostTitle.Text = "CHI PHÍ THÁNG NÀY";
            // 
            // lblMonthCostIcon
            // 
            lblMonthCostIcon.BackColor = Color.Transparent;
            lblMonthCostIcon.Font = new Font("Segoe UI Emoji", 18F);
            lblMonthCostIcon.ForeColor = Color.FromArgb(0, 230, 118);
            lblMonthCostIcon.Location = new Point(14, 5);
            lblMonthCostIcon.Name = "lblMonthCostIcon";
            lblMonthCostIcon.Size = new Size(58, 40);
            lblMonthCostIcon.TabIndex = 0;
            lblMonthCostIcon.Text = "💰";
            // 
            // pnlTitleBar
            // 
            pnlTitleBar.Controls.Add(lblSubtitle);
            pnlTitleBar.Controls.Add(lblTitle);
            pnlTitleBar.Dock = DockStyle.Top;
            pnlTitleBar.Location = new Point(0, 0);
            pnlTitleBar.Name = "pnlTitleBar";
            pnlTitleBar.Padding = new Padding(20, 0, 0, 0);
            pnlTitleBar.Size = new Size(1060, 70);
            pnlTitleBar.TabIndex = 4;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(120, 144, 156);
            lblSubtitle.Location = new Point(18, 48);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(257, 20);
            lblSubtitle.TabIndex = 0;
            lblSubtitle.Text = "Ước tính chi phí lãng phí do rò rỉ điện";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Emoji", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(20, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(340, 36);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "💸  Phân Tích Thất Thoát";
            // 
            // PowerLossAnalysisForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(1060, 660);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PowerLossAnalysisForm";
            Text = "PowerLossAnalysisForm";
            pnlMain.ResumeLayout(false);
            pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetails).EndInit();
            pnlActions.ResumeLayout(false);
            pnlCharts.ResumeLayout(false);
            pnlCards.ResumeLayout(false);
            pnlLossCurrent.ResumeLayout(false);
            pnlLossEnergy.ResumeLayout(false);
            pnlLossCost.ResumeLayout(false);
            pnlLossMonthCost.ResumeLayout(false);
            pnlTitleBar.ResumeLayout(false);
            pnlTitleBar.PerformLayout();
            ResumeLayout(false);
        }



        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TableLayoutPanel pnlCards;
        private System.Windows.Forms.TableLayoutPanel pnlCharts;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvDetails;

        private System.Windows.Forms.Label lblCurrentLoss;

        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chartEnergy;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chartCost;

        private Guna.UI2.WinForms.Guna2Button btnAI;
        private Guna.UI2.WinForms.Guna2Button btnExportExcel;
        private Guna.UI2.WinForms.Guna2Button btnExportPdf;
        private Guna.UI2.WinForms.Guna2Button btnConfigPrice;
        private System.Windows.Forms.Label lblAIResult;
    }
}
