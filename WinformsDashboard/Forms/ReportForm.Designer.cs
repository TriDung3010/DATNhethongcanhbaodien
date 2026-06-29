namespace WinformsDashboard.Forms
{
    partial class ReportForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend skDefaultLegend1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultLegend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReportForm));
            LiveChartsCore.Drawing.Padding padding1 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip skDefaultTooltip1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip();
            LiveChartsCore.Drawing.Padding padding2 = new LiveChartsCore.Drawing.Padding();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlMain = new Panel();
            pnlChart = new Panel();
            pieChart = new LiveChartsCore.SkiaSharpView.WinForms.PieChart();
            pnlCards = new TableLayoutPanel();
            pnlCard1 = new Guna.UI2.WinForms.Guna2Panel();
            lblTotalAlerts = new Label();
            lblTotalAlertsText = new Label();
            lblCard1Icon = new Label();
            pnlCard2 = new Guna.UI2.WinForms.Guna2Panel();
            lblMaxLeakage = new Label();
            lblMaxLeakageText = new Label();
            lblCard2Icon = new Label();
            pnlCard3 = new Guna.UI2.WinForms.Guna2Panel();
            lblAvgLeakage = new Label();
            lblAvgLeakageText = new Label();
            lblCard3Icon = new Label();
            pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            btnGenerate = new Guna.UI2.WinForms.Guna2GradientButton();
            dtpEndDate = new DateTimePicker();
            lblEndDate = new Label();
            dtpStartDate = new DateTimePicker();
            lblStartDate = new Label();
            pnlTitleBar = new Panel();
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            pnlChart.SuspendLayout();
            pnlCards.SuspendLayout();
            pnlCard1.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlFilter.SuspendLayout();
            pnlTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(240, 242, 245);
            pnlMain.Controls.Add(pnlChart);
            pnlMain.Controls.Add(pnlCards);
            pnlMain.Controls.Add(pnlFilter);
            pnlMain.Controls.Add(pnlTitleBar);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1060, 660);
            pnlMain.TabIndex = 0;
            // 
            // pnlChart
            // 
            pnlChart.BackColor = Color.FromArgb(240, 242, 245);
            pnlChart.Controls.Add(pieChart);
            pnlChart.Dock = DockStyle.Fill;
            pnlChart.Location = new Point(0, 275);
            pnlChart.Name = "pnlChart";
            pnlChart.Padding = new Padding(10, 5, 10, 10);
            pnlChart.Size = new Size(1060, 385);
            pnlChart.TabIndex = 0;
            // 
            // pieChart
            // 
            pieChart.AutoUpdateEnabled = true;
            pieChart.BackColor = Color.FromArgb(240, 242, 245);
            pieChart.ChartTheme = null;
            pieChart.Dock = DockStyle.Fill;
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
            pieChart.Legend = skDefaultLegend1;
            pieChart.Location = new Point(10, 5);
            pieChart.Name = "pieChart";
            pieChart.Size = new Size(1040, 370);
            pieChart.TabIndex = 0;
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
            pieChart.Tooltip = skDefaultTooltip1;
            pieChart.UpdaterThrottler = TimeSpan.Parse("00:00:00.0500000");
            // 
            // pnlCards
            // 
            pnlCards.BackColor = Color.Transparent;
            pnlCards.ColumnCount = 3;
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3F));
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.4F));
            pnlCards.Controls.Add(pnlCard1, 0, 0);
            pnlCards.Controls.Add(pnlCard2, 1, 0);
            pnlCards.Controls.Add(pnlCard3, 2, 0);
            pnlCards.Dock = DockStyle.Top;
            pnlCards.Location = new Point(0, 125);
            pnlCards.Name = "pnlCards";
            pnlCards.Padding = new Padding(8);
            pnlCards.RowCount = 1;
            pnlCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlCards.Size = new Size(1060, 150);
            pnlCards.TabIndex = 1;
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = Color.Transparent;
            pnlCard1.BorderRadius = 12;
            pnlCard1.Controls.Add(lblTotalAlerts);
            pnlCard1.Controls.Add(lblTotalAlertsText);
            pnlCard1.Controls.Add(lblCard1Icon);
            pnlCard1.CustomizableEdges = customizableEdges1;
            pnlCard1.Dock = DockStyle.Fill;
            pnlCard1.FillColor = Color.FromArgb(255, 255, 255);
            pnlCard1.Location = new Point(13, 13);
            pnlCard1.Margin = new Padding(5);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlCard1.Size = new Size(337, 124);
            pnlCard1.TabIndex = 0;
            // 
            // lblTotalAlerts
            // 
            lblTotalAlerts.AutoSize = true;
            lblTotalAlerts.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalAlerts.ForeColor = Color.FromArgb(255, 23, 68);
            lblTotalAlerts.Location = new Point(13, 73);
            lblTotalAlerts.Name = "lblTotalAlerts";
            lblTotalAlerts.Size = new Size(59, 50);
            lblTotalAlerts.TabIndex = 0;
            lblTotalAlerts.Text = "—";
            // 
            // lblTotalAlertsText
            // 
            lblTotalAlertsText.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblTotalAlertsText.ForeColor = Color.FromArgb(120, 144, 156);
            lblTotalAlertsText.Location = new Point(14, 50);
            lblTotalAlertsText.Name = "lblTotalAlertsText";
            lblTotalAlertsText.Size = new Size(180, 18);
            lblTotalAlertsText.TabIndex = 1;
            lblTotalAlertsText.Text = "TỔNG CẢNH BÁO";
            // 
            // lblCard1Icon
            // 
            lblCard1Icon.AutoSize = true;
            lblCard1Icon.Font = new Font("Segoe UI Emoji", 18F);
            lblCard1Icon.ForeColor = Color.FromArgb(255, 23, 68);
            lblCard1Icon.Location = new Point(14, 10);
            lblCard1Icon.Name = "lblCard1Icon";
            lblCard1Icon.Size = new Size(58, 40);
            lblCard1Icon.TabIndex = 2;
            lblCard1Icon.Text = "🔔";
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = Color.Transparent;
            pnlCard2.BorderRadius = 12;
            pnlCard2.Controls.Add(lblMaxLeakage);
            pnlCard2.Controls.Add(lblMaxLeakageText);
            pnlCard2.Controls.Add(lblCard2Icon);
            pnlCard2.CustomizableEdges = customizableEdges3;
            pnlCard2.Dock = DockStyle.Fill;
            pnlCard2.FillColor = Color.FromArgb(255, 255, 255);
            pnlCard2.Location = new Point(360, 13);
            pnlCard2.Margin = new Padding(5);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlCard2.Size = new Size(337, 124);
            pnlCard2.TabIndex = 1;
            // 
            // lblMaxLeakage
            // 
            lblMaxLeakage.AutoSize = true;
            lblMaxLeakage.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblMaxLeakage.ForeColor = Color.FromArgb(255, 214, 0);
            lblMaxLeakage.Location = new Point(14, 73);
            lblMaxLeakage.Name = "lblMaxLeakage";
            lblMaxLeakage.Size = new Size(129, 50);
            lblMaxLeakage.TabIndex = 0;
            lblMaxLeakage.Text = "— mA";
            // 
            // lblMaxLeakageText
            // 
            lblMaxLeakageText.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblMaxLeakageText.ForeColor = Color.FromArgb(120, 144, 156);
            lblMaxLeakageText.Location = new Point(14, 50);
            lblMaxLeakageText.Name = "lblMaxLeakageText";
            lblMaxLeakageText.Size = new Size(180, 18);
            lblMaxLeakageText.TabIndex = 1;
            lblMaxLeakageText.Text = "DÒNG RÒ CAO NHẤT";
            // 
            // lblCard2Icon
            // 
            lblCard2Icon.AutoSize = true;
            lblCard2Icon.Font = new Font("Segoe UI Emoji", 18F);
            lblCard2Icon.ForeColor = Color.FromArgb(255, 214, 0);
            lblCard2Icon.Location = new Point(14, 10);
            lblCard2Icon.Name = "lblCard2Icon";
            lblCard2Icon.Size = new Size(58, 40);
            lblCard2Icon.TabIndex = 2;
            lblCard2Icon.Text = "⚡";
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = Color.Transparent;
            pnlCard3.BorderRadius = 12;
            pnlCard3.Controls.Add(lblAvgLeakage);
            pnlCard3.Controls.Add(lblAvgLeakageText);
            pnlCard3.Controls.Add(lblCard3Icon);
            pnlCard3.CustomizableEdges = customizableEdges5;
            pnlCard3.Dock = DockStyle.Fill;
            pnlCard3.FillColor = Color.FromArgb(255, 255, 255);
            pnlCard3.Location = new Point(707, 13);
            pnlCard3.Margin = new Padding(5);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlCard3.Size = new Size(340, 124);
            pnlCard3.TabIndex = 2;
            // 
            // lblAvgLeakage
            // 
            lblAvgLeakage.AutoSize = true;
            lblAvgLeakage.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblAvgLeakage.ForeColor = Color.FromArgb(0, 230, 118);
            lblAvgLeakage.Location = new Point(14, 73);
            lblAvgLeakage.Name = "lblAvgLeakage";
            lblAvgLeakage.Size = new Size(129, 50);
            lblAvgLeakage.TabIndex = 0;
            lblAvgLeakage.Text = "— mA";
            lblAvgLeakage.Click += lblAvgLeakage_Click;
            // 
            // lblAvgLeakageText
            // 
            lblAvgLeakageText.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblAvgLeakageText.ForeColor = Color.FromArgb(120, 144, 156);
            lblAvgLeakageText.Location = new Point(14, 50);
            lblAvgLeakageText.Name = "lblAvgLeakageText";
            lblAvgLeakageText.Size = new Size(180, 18);
            lblAvgLeakageText.TabIndex = 1;
            lblAvgLeakageText.Text = "DÒNG RÒ TRUNG BÌNH";
            // 
            // lblCard3Icon
            // 
            lblCard3Icon.AutoSize = true;
            lblCard3Icon.Font = new Font("Segoe UI Emoji", 18F);
            lblCard3Icon.ForeColor = Color.FromArgb(0, 230, 118);
            lblCard3Icon.Location = new Point(14, 10);
            lblCard3Icon.Name = "lblCard3Icon";
            lblCard3Icon.Size = new Size(58, 40);
            lblCard3Icon.TabIndex = 2;
            lblCard3Icon.Text = "📈";
            // 
            // pnlFilter
            // 
            pnlFilter.BackColor = Color.Transparent;
            pnlFilter.BorderRadius = 10;
            pnlFilter.Controls.Add(btnGenerate);
            pnlFilter.Controls.Add(dtpEndDate);
            pnlFilter.Controls.Add(lblEndDate);
            pnlFilter.Controls.Add(dtpStartDate);
            pnlFilter.Controls.Add(lblStartDate);
            pnlFilter.CustomizableEdges = customizableEdges9;
            pnlFilter.Dock = DockStyle.Top;
            pnlFilter.FillColor = Color.FromArgb(255, 255, 255);
            pnlFilter.Location = new Point(0, 60);
            pnlFilter.Name = "pnlFilter";
            pnlFilter.Padding = new Padding(15, 12, 15, 12);
            pnlFilter.ShadowDecoration.CustomizableEdges = customizableEdges10;
            pnlFilter.Size = new Size(1060, 65);
            pnlFilter.TabIndex = 2;
            // 
            // btnGenerate
            // 
            btnGenerate.BorderRadius = 8;
            btnGenerate.CustomizableEdges = customizableEdges7;
            btnGenerate.FillColor = Color.FromArgb(0, 145, 234);
            btnGenerate.FillColor2 = Color.FromArgb(0, 176, 255);
            btnGenerate.Font = new Font("Segoe UI Emoji", 10F, FontStyle.Bold);
            btnGenerate.ForeColor = Color.White;
            btnGenerate.Location = new Point(510, 11);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnGenerate.Size = new Size(187, 38);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "📊  Tạo Báo Cáo";
            // 
            // dtpEndDate
            // 
            dtpEndDate.CalendarForeColor = Color.FromArgb(33, 37, 41);
            dtpEndDate.CalendarMonthBackground = Color.FromArgb(255, 255, 255);
            dtpEndDate.CalendarTitleBackColor = Color.FromArgb(0, 145, 234);
            dtpEndDate.CalendarTitleForeColor = Color.FromArgb(33, 37, 41);
            dtpEndDate.Font = new Font("Segoe UI", 10F);
            dtpEndDate.ForeColor = Color.FromArgb(33, 37, 41);
            dtpEndDate.Format = DateTimePickerFormat.Short;
            dtpEndDate.Location = new Point(345, 11);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(140, 30);
            dtpEndDate.TabIndex = 1;
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEndDate.ForeColor = Color.FromArgb(0, 176, 255);
            lblEndDate.Location = new Point(249, 16);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(90, 20);
            lblEndDate.TabIndex = 2;
            lblEndDate.Text = "ĐẾN NGÀY:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CalendarForeColor = Color.FromArgb(33, 37, 41);
            dtpStartDate.CalendarMonthBackground = Color.FromArgb(255, 255, 255);
            dtpStartDate.CalendarTitleBackColor = Color.FromArgb(0, 145, 234);
            dtpStartDate.CalendarTitleForeColor = Color.FromArgb(33, 37, 41);
            dtpStartDate.Font = new Font("Segoe UI", 10F);
            dtpStartDate.ForeColor = Color.FromArgb(33, 37, 41);
            dtpStartDate.Format = DateTimePickerFormat.Short;
            dtpStartDate.Location = new Point(94, 11);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(140, 30);
            dtpStartDate.TabIndex = 3;
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblStartDate.ForeColor = Color.FromArgb(0, 176, 255);
            lblStartDate.Location = new Point(15, 16);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(80, 20);
            lblStartDate.TabIndex = 4;
            lblStartDate.Text = "TỪ NGÀY:";
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
            lblTitle.Size = new Size(286, 33);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📊  Báo Cáo Thống Kê";
            // 
            // ReportForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(1060, 660);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReportForm";
            Text = "ReportForm";
            pnlMain.ResumeLayout(false);
            pnlChart.ResumeLayout(false);
            pnlCards.ResumeLayout(false);
            pnlCard1.ResumeLayout(false);
            pnlCard1.PerformLayout();
            pnlCard2.ResumeLayout(false);
            pnlCard2.PerformLayout();
            pnlCard3.ResumeLayout(false);
            pnlCard3.PerformLayout();
            pnlFilter.ResumeLayout(false);
            pnlFilter.PerformLayout();
            pnlTitleBar.ResumeLayout(false);
            pnlTitleBar.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel                         pnlMain;
        private System.Windows.Forms.Panel                         pnlTitleBar;
        private System.Windows.Forms.Label                         lblTitle;
        private Guna.UI2.WinForms.Guna2Panel                       pnlFilter;
        private System.Windows.Forms.Label                         lblStartDate;
        private System.Windows.Forms.DateTimePicker                dtpStartDate;
        private System.Windows.Forms.Label                         lblEndDate;
        private System.Windows.Forms.DateTimePicker                dtpEndDate;
        private Guna.UI2.WinForms.Guna2GradientButton              btnGenerate;
        private System.Windows.Forms.TableLayoutPanel              pnlCards;
        private Guna.UI2.WinForms.Guna2Panel                       pnlCard1;
        private System.Windows.Forms.Label                         lblCard1Icon;
        private System.Windows.Forms.Label                         lblTotalAlertsText;
        private System.Windows.Forms.Label                         lblTotalAlerts;
        private Guna.UI2.WinForms.Guna2Panel                       pnlCard2;
        private System.Windows.Forms.Label                         lblCard2Icon;
        private System.Windows.Forms.Label                         lblMaxLeakageText;
        private System.Windows.Forms.Label                         lblMaxLeakage;
        private Guna.UI2.WinForms.Guna2Panel                       pnlCard3;
        private System.Windows.Forms.Label                         lblCard3Icon;
        private System.Windows.Forms.Label                         lblAvgLeakageText;
        private System.Windows.Forms.Label                         lblAvgLeakage;
        private System.Windows.Forms.Panel                         pnlChart;
        private LiveChartsCore.SkiaSharpView.WinForms.PieChart     pieChart;
    }
}

