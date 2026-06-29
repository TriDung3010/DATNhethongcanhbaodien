using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using WinformsDashboard.DataAccess;
using WinformsDashboard.Helpers;
using WinformsDashboard.Models;
using WinformsDashboard.Services;

namespace WinformsDashboard.Forms
{
    public partial class DashboardForm : Form
    {
        private readonly DeviceRepository _deviceRepo = new DeviceRepository();
        private readonly AlertRepository _alertRepo = new AlertRepository();

        private ObservableCollection<ObservablePoint> _chartData = new();
        private int _timeIndex = 0;
        private Axis _xAxis = new Axis();

        public DashboardForm()
        {
            InitializeComponent();
            SetupChart();
            LoadDashboardData();
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            IoTService.Instance.OnDataReceived += OnIoTDataReceived;
            IoTService.Instance.OnAlertTriggered += OnIoTAlertTriggered;
        }

        private void SetupChart()
        {
            _chartData = new ObservableCollection<ObservablePoint>();

            chartView.Series = new ISeries[]
            {
                new LineSeries<ObservablePoint>
                {
                    Values = _chartData,
                    Name = "Dòng rò (mA)",
                    Stroke = new SolidColorPaint(new SKColor(0, 176, 255)) { StrokeThickness = 3 },
                    GeometryFill = new SolidColorPaint(new SKColor(0, 176, 255)),
                    GeometryStroke = new SolidColorPaint(new SKColor(0, 176, 255)),
                    GeometrySize = 4,
                    Fill = new LinearGradientPaint(
                        new[] { new SKColor(0, 176, 255, 60), new SKColor(0, 176, 255, 0) },
                        new SKPoint(0.5f, 0f),
                        new SKPoint(0.5f, 1f))
                }
            };

            chartView.Sections = new[]
            {
                new RectangularSection
                {
                    Yi = 30,
                    Yj = 100,
                    Fill = new SolidColorPaint(new SKColor(255, 23, 68, 20))
                },
                new RectangularSection
                {
                    Yi = 15,
                    Yj = 30,
                    Fill = new SolidColorPaint(new SKColor(255, 214, 0, 20))
                }
            };

            _xAxis = new Axis
            {
                Name = "Thời gian (s)",
                NamePaint = new SolidColorPaint(new SKColor(120, 144, 156)),
                LabelsPaint = new SolidColorPaint(new SKColor(120, 144, 156)),
                MinLimit = 0,
                MaxLimit = 50,
                MinStep = 5,
                Labeler = value => value.ToString("0")
            };

            chartView.XAxes = new[] { _xAxis };

            chartView.YAxes = new[]
            {
                new Axis
                {
                    Name = "Dòng điện (mA)",
                    NamePaint = new SolidColorPaint(new SKColor(120, 144, 156)),
                    LabelsPaint = new SolidColorPaint(new SKColor(120, 144, 156)),
                    SeparatorsPaint = new SolidColorPaint(new SKColor(255, 255, 255)),
                    MinLimit = 0,
                    MaxLimit = 100
                }
            };

            chartView.BackColor = Color.FromArgb(240, 242, 245);
        }

        private void UnsubscribeFromEvents()
        {
            IoTService.Instance.OnDataReceived -= OnIoTDataReceived;
            IoTService.Instance.OnAlertTriggered -= OnIoTAlertTriggered;
        }

        private void OnIoTDataReceived(object? sender, SensorData data)
        {
            if (this.InvokeRequired) { this.Invoke(new Action(() => OnIoTDataReceived(sender, data))); return; }

            double v = data.LeakageCurrent;
            Color c = AppTheme.GetLeakageColor(v);

            lblCurrentLeakage.Text = v.ToString("F2") + " mA";
            lblCard3Icon.ForeColor = c;
            lblCurrentLeakage.ForeColor = c;

            lblSystemStatus.Text = AppTheme.GetLeakageStatus(v);
            lblSystemStatus.ForeColor = c;
            lblCard4Icon.ForeColor = c;

            _chartData.Add(new ObservablePoint(_timeIndex, v));
            _timeIndex++;

            if (_chartData.Count > 50) _chartData.RemoveAt(0);

            if (_timeIndex > 50)
            {
                _xAxis.MinLimit = _timeIndex - 50;
                _xAxis.MaxLimit = _timeIndex;
            }
        }

        private void OnIoTAlertTriggered(object? sender, Alert alert)
        {
            if (this.InvokeRequired) { this.Invoke(new Action(() => OnIoTAlertTriggered(sender, alert))); return; }

            if (int.TryParse(lblAlertsToday.Text, out int count))
                lblAlertsToday.Text = (count + 1).ToString();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            UnsubscribeFromEvents();
            base.OnFormClosing(e);
        }

        private void LoadDashboardData()
        {
            try
            {
                lblTotalDevices.Text = _deviceRepo.GetAllDevices().Count.ToString();

                var alertsToday = _alertRepo.GetAllAlerts()
                    .Where(a => a.AlertTime >= DateTime.Today).ToList();
                lblAlertsToday.Text = alertsToday.Count.ToString();

                lblCurrentLeakage.Text = "0.00 mA";

                if (alertsToday.Count > 0)
                {
                    lblSystemStatus.Text = "⚠ ĐÃ CÓ CẢNH BÁO";
                    lblSystemStatus.ForeColor = AppTheme.ColorWarning;
                    lblCard4Icon.ForeColor = AppTheme.ColorWarning;
                }
                else
                {
                    lblSystemStatus.Text = "✅ AN TOÀN";
                    lblSystemStatus.ForeColor = AppTheme.ColorSafe;
                    lblCard4Icon.ForeColor = AppTheme.ColorSafe;
                }
            }
            catch { /* Bỏ qua lỗi DB trong mode Designer */ }
        }

        private void lblCard2Icon_Click(object sender, EventArgs e)
        {

        }

        private void lblCard3Icon_Click(object sender, EventArgs e)
        {

        }
    }
}
