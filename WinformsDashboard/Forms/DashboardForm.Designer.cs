namespace WinformsDashboard.Forms
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            LiveChartsCore.Drawing.Padding padding1 = new LiveChartsCore.Drawing.Padding();
            LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip skDefaultTooltip1 = new LiveChartsCore.SkiaSharpView.SKCharts.SKDefaultTooltip();
            LiveChartsCore.Drawing.Padding padding2 = new LiveChartsCore.Drawing.Padding();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlMain = new Panel();
            chartView = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            pnlCards = new TableLayoutPanel();
            pnlCard1 = new Guna.UI2.WinForms.Guna2Panel();
            lblTotalDevices = new Label();
            lblCard1Title = new Label();
            lblCard1Icon = new Label();
            pnlCard2 = new Guna.UI2.WinForms.Guna2Panel();
            lblAlertsToday = new Label();
            lblCard2Title = new Label();
            lblCard2Icon = new Label();
            pnlCard3 = new Guna.UI2.WinForms.Guna2Panel();
            lblCurrentLeakage = new Label();
            lblCard3Title = new Label();
            lblCard3Icon = new Label();
            pnlCard4 = new Guna.UI2.WinForms.Guna2Panel();
            lblSystemStatus = new Label();
            lblCard4Title = new Label();
            lblCard4Icon = new Label();
            pnlTitleBar = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            pnlMain.SuspendLayout();
            pnlCards.SuspendLayout();
            pnlCard1.SuspendLayout();
            pnlCard2.SuspendLayout();
            pnlCard3.SuspendLayout();
            pnlCard4.SuspendLayout();
            pnlTitleBar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(240, 242, 245);
            pnlMain.Controls.Add(chartView);
            pnlMain.Controls.Add(pnlCards);
            pnlMain.Controls.Add(pnlTitleBar);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(0, 0, 0, 20);
            pnlMain.Size = new Size(1060, 660);
            pnlMain.TabIndex = 0;
            // 
            // chartView
            // 
            chartView.AutoUpdateEnabled = true;
            chartView.BackColor = Color.FromArgb(240, 242, 245);
            chartView.ChartTheme = null;
            chartView.Dock = DockStyle.Fill;
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
            chartView.Legend = skDefaultLegend1;
            chartView.Location = new Point(0, 210);
            chartView.Margin = new Padding(20);
            chartView.MatchAxesScreenDataRatio = false;
            chartView.Name = "chartView";
            chartView.Padding = new Padding(20);
            chartView.Size = new Size(1060, 430);
            chartView.TabIndex = 0;
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
            chartView.Tooltip = skDefaultTooltip1;
            chartView.FindingStrategy = LiveChartsCore.Measure.FindingStrategy.Automatic;
            chartView.UpdaterThrottler = TimeSpan.Parse("00:00:00.0500000");
            // 
            // pnlCards
            // 
            pnlCards.BackColor = Color.Transparent;
            pnlCards.ColumnCount = 4;
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            pnlCards.Controls.Add(pnlCard1, 0, 0);
            pnlCards.Controls.Add(pnlCard2, 1, 0);
            pnlCards.Controls.Add(pnlCard3, 2, 0);
            pnlCards.Controls.Add(pnlCard4, 3, 0);
            pnlCards.Dock = DockStyle.Top;
            pnlCards.Location = new Point(0, 70);
            pnlCards.Name = "pnlCards";
            pnlCards.Padding = new Padding(12, 0, 12, 10);
            pnlCards.RowCount = 1;
            pnlCards.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlCards.Size = new Size(1060, 140);
            pnlCards.TabIndex = 1;
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = Color.Transparent;
            pnlCard1.BorderRadius = 12;
            pnlCard1.Controls.Add(lblTotalDevices);
            pnlCard1.Controls.Add(lblCard1Title);
            pnlCard1.Controls.Add(lblCard1Icon);
            pnlCard1.CustomizableEdges = customizableEdges1;
            pnlCard1.Dock = DockStyle.Fill;
            pnlCard1.FillColor = Color.FromArgb(255, 255, 255);
            pnlCard1.Location = new Point(18, 6);
            pnlCard1.Margin = new Padding(6);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlCard1.Size = new Size(247, 118);
            pnlCard1.TabIndex = 0;
            // 
            // lblTotalDevices
            // 
            lblTotalDevices.AutoSize = true;
            lblTotalDevices.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTotalDevices.ForeColor = Color.FromArgb(0, 176, 255);
            lblTotalDevices.Location = new Point(14, 65);
            lblTotalDevices.Name = "lblTotalDevices";
            lblTotalDevices.Size = new Size(40, 46);
            lblTotalDevices.TabIndex = 0;
            lblTotalDevices.Text = "0";
            // 
            // lblCard1Title
            // 
            lblCard1Title.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblCard1Title.ForeColor = Color.FromArgb(120, 144, 156);
            lblCard1Title.Location = new Point(14, 47);
            lblCard1Title.Name = "lblCard1Title";
            lblCard1Title.Size = new Size(160, 18);
            lblCard1Title.TabIndex = 1;
            lblCard1Title.Text = "TỔNG THIẾT BỊ";
            // 
            // lblCard1Icon
            // 
            lblCard1Icon.AutoSize = true;
            lblCard1Icon.Font = new Font("Segoe UI Emoji", 18F);
            lblCard1Icon.ForeColor = Color.FromArgb(0, 176, 255);
            lblCard1Icon.Location = new Point(14, 0);
            lblCard1Icon.Name = "lblCard1Icon";
            lblCard1Icon.Size = new Size(58, 40);
            lblCard1Icon.TabIndex = 2;
            lblCard1Icon.Text = "🔌";
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = Color.Transparent;
            pnlCard2.BorderRadius = 12;
            pnlCard2.Controls.Add(lblAlertsToday);
            pnlCard2.Controls.Add(lblCard2Title);
            pnlCard2.Controls.Add(lblCard2Icon);
            pnlCard2.CustomizableEdges = customizableEdges3;
            pnlCard2.Dock = DockStyle.Fill;
            pnlCard2.FillColor = Color.FromArgb(255, 255, 255);
            pnlCard2.Location = new Point(277, 6);
            pnlCard2.Margin = new Padding(6);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlCard2.Size = new Size(247, 118);
            pnlCard2.TabIndex = 1;
            // 
            // lblAlertsToday
            // 
            lblAlertsToday.AutoSize = true;
            lblAlertsToday.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblAlertsToday.ForeColor = Color.FromArgb(255, 23, 68);
            lblAlertsToday.Location = new Point(14, 65);
            lblAlertsToday.Name = "lblAlertsToday";
            lblAlertsToday.Size = new Size(40, 46);
            lblAlertsToday.TabIndex = 0;
            lblAlertsToday.Text = "0";
            // 
            // lblCard2Title
            // 
            lblCard2Title.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblCard2Title.ForeColor = Color.FromArgb(120, 144, 156);
            lblCard2Title.Location = new Point(14, 47);
            lblCard2Title.Name = "lblCard2Title";
            lblCard2Title.Size = new Size(160, 18);
            lblCard2Title.TabIndex = 1;
            lblCard2Title.Text = "CẢNH BÁO HÔM NAY";
            // 
            // lblCard2Icon
            // 
            lblCard2Icon.AutoSize = true;
            lblCard2Icon.Font = new Font("Segoe UI Emoji", 18F);
            lblCard2Icon.ForeColor = Color.FromArgb(255, 23, 68);
            lblCard2Icon.Location = new Point(14, 5);
            lblCard2Icon.Name = "lblCard2Icon";
            lblCard2Icon.Size = new Size(58, 40);
            lblCard2Icon.TabIndex = 2;
            lblCard2Icon.Text = "🔔";
            lblCard2Icon.Click += lblCard2Icon_Click;
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = Color.Transparent;
            pnlCard3.BorderRadius = 12;
            pnlCard3.Controls.Add(lblCurrentLeakage);
            pnlCard3.Controls.Add(lblCard3Title);
            pnlCard3.Controls.Add(lblCard3Icon);
            pnlCard3.CustomizableEdges = customizableEdges5;
            pnlCard3.Dock = DockStyle.Fill;
            pnlCard3.FillColor = Color.FromArgb(255, 255, 255);
            pnlCard3.Location = new Point(536, 6);
            pnlCard3.Margin = new Padding(6);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.ShadowDecoration.CustomizableEdges = customizableEdges6;
            pnlCard3.Size = new Size(247, 118);
            pnlCard3.TabIndex = 2;
            // 
            // lblCurrentLeakage
            // 
            lblCurrentLeakage.AutoSize = true;
            lblCurrentLeakage.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblCurrentLeakage.ForeColor = Color.FromArgb(255, 214, 0);
            lblCurrentLeakage.Location = new Point(14, 65);
            lblCurrentLeakage.Name = "lblCurrentLeakage";
            lblCurrentLeakage.Size = new Size(153, 46);
            lblCurrentLeakage.TabIndex = 0;
            lblCurrentLeakage.Text = "0.00 mA";
            // 
            // lblCard3Title
            // 
            lblCard3Title.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblCard3Title.ForeColor = Color.FromArgb(120, 144, 156);
            lblCard3Title.Location = new Point(14, 47);
            lblCard3Title.Name = "lblCard3Title";
            lblCard3Title.Size = new Size(160, 18);
            lblCard3Title.TabIndex = 1;
            lblCard3Title.Text = "DÒNG RÒ HIỆN TẠI";
            // 
            // lblCard3Icon
            // 
            lblCard3Icon.AutoSize = true;
            lblCard3Icon.Font = new Font("Segoe UI Emoji", 18F);
            lblCard3Icon.ForeColor = Color.FromArgb(255, 214, 0);
            lblCard3Icon.Location = new Point(14, 5);
            lblCard3Icon.Name = "lblCard3Icon";
            lblCard3Icon.Size = new Size(58, 40);
            lblCard3Icon.TabIndex = 2;
            lblCard3Icon.Text = "⚡";
            lblCard3Icon.Click += lblCard3Icon_Click;
            // 
            // pnlCard4
            // 
            pnlCard4.BackColor = Color.Transparent;
            pnlCard4.BorderRadius = 12;
            pnlCard4.Controls.Add(lblSystemStatus);
            pnlCard4.Controls.Add(lblCard4Title);
            pnlCard4.Controls.Add(lblCard4Icon);
            pnlCard4.CustomizableEdges = customizableEdges7;
            pnlCard4.Dock = DockStyle.Fill;
            pnlCard4.FillColor = Color.FromArgb(255, 255, 255);
            pnlCard4.Location = new Point(795, 6);
            pnlCard4.Margin = new Padding(6);
            pnlCard4.Name = "pnlCard4";
            pnlCard4.ShadowDecoration.CustomizableEdges = customizableEdges8;
            pnlCard4.Size = new Size(247, 118);
            pnlCard4.TabIndex = 3;
            // 
            // lblSystemStatus
            // 
            lblSystemStatus.AutoSize = true;
            lblSystemStatus.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblSystemStatus.ForeColor = Color.FromArgb(0, 230, 118);
            lblSystemStatus.Location = new Point(14, 65);
            lblSystemStatus.Name = "lblSystemStatus";
            lblSystemStatus.Size = new Size(175, 46);
            lblSystemStatus.TabIndex = 0;
            lblSystemStatus.Text = "AN TOÀN";
            // 
            // lblCard4Title
            // 
            lblCard4Title.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblCard4Title.ForeColor = Color.FromArgb(120, 144, 156);
            lblCard4Title.Location = new Point(14, 47);
            lblCard4Title.Name = "lblCard4Title";
            lblCard4Title.Size = new Size(160, 18);
            lblCard4Title.TabIndex = 1;
            lblCard4Title.Text = "TRẠNG THÁI";
            // 
            // lblCard4Icon
            // 
            lblCard4Icon.AutoSize = true;
            lblCard4Icon.Font = new Font("Segoe UI Emoji", 18F);
            lblCard4Icon.ForeColor = Color.FromArgb(0, 230, 118);
            lblCard4Icon.Location = new Point(14, 5);
            lblCard4Icon.Name = "lblCard4Icon";
            lblCard4Icon.Size = new Size(58, 40);
            lblCard4Icon.TabIndex = 2;
            lblCard4Icon.Text = "✅";
            // 
            // pnlTitleBar
            // 
            pnlTitleBar.BackColor = Color.Transparent;
            pnlTitleBar.Controls.Add(lblSubtitle);
            pnlTitleBar.Controls.Add(lblTitle);
            pnlTitleBar.Dock = DockStyle.Top;
            pnlTitleBar.Location = new Point(0, 0);
            pnlTitleBar.Name = "pnlTitleBar";
            pnlTitleBar.Padding = new Padding(20, 0, 0, 0);
            pnlTitleBar.Size = new Size(1060, 70);
            pnlTitleBar.TabIndex = 2;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(120, 144, 156);
            lblSubtitle.Location = new Point(23, 52);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(240, 20);
            lblSubtitle.TabIndex = 0;
            lblSubtitle.Text = "Cập nhật realtime từ thiết bị ESP32";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Emoji", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(20, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(347, 36);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "⚡  Tổng Quan Hệ Thống";
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 242, 245);
            ClientSize = new Size(1060, 660);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DashboardForm";
            Text = "Dashboard";
            pnlMain.ResumeLayout(false);
            pnlCards.ResumeLayout(false);
            pnlCard1.ResumeLayout(false);
            pnlCard1.PerformLayout();
            pnlCard2.ResumeLayout(false);
            pnlCard2.PerformLayout();
            pnlCard3.ResumeLayout(false);
            pnlCard3.PerformLayout();
            pnlCard4.ResumeLayout(false);
            pnlCard4.PerformLayout();
            pnlTitleBar.ResumeLayout(false);
            pnlTitleBar.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel          pnlMain;
        private System.Windows.Forms.Panel          pnlTitleBar;
        private System.Windows.Forms.Label          lblTitle;
        private System.Windows.Forms.Label          lblSubtitle;
        private System.Windows.Forms.TableLayoutPanel pnlCards;
        private Guna.UI2.WinForms.Guna2Panel        pnlCard1;
        private System.Windows.Forms.Label          lblCard1Icon;
        private System.Windows.Forms.Label          lblCard1Title;
        private System.Windows.Forms.Label          lblTotalDevices;
        private Guna.UI2.WinForms.Guna2Panel        pnlCard2;
        private System.Windows.Forms.Label          lblCard2Icon;
        private System.Windows.Forms.Label          lblCard2Title;
        private System.Windows.Forms.Label          lblAlertsToday;
        private Guna.UI2.WinForms.Guna2Panel        pnlCard3;
        private System.Windows.Forms.Label          lblCard3Icon;
        private System.Windows.Forms.Label          lblCard3Title;
        private System.Windows.Forms.Label          lblCurrentLeakage;
        private Guna.UI2.WinForms.Guna2Panel        pnlCard4;
        private System.Windows.Forms.Label          lblCard4Icon;
        private System.Windows.Forms.Label          lblCard4Title;
        private System.Windows.Forms.Label          lblSystemStatus;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart chartView;
    }
}
