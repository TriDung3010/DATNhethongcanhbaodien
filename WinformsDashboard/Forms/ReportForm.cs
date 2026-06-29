using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using WinformsDashboard.DataAccess;

namespace WinformsDashboard.Forms
{
    public partial class ReportForm : Form
    {
        private readonly AlertRepository _alertRepo = new AlertRepository();
        private readonly SensorDataRepository _sensorRepo = new SensorDataRepository();
        private readonly DeviceRepository _deviceRepo = new DeviceRepository();

        public ReportForm()
        {
            InitializeComponent();
            btnGenerate.Click += BtnGenerate_Click;

            // Default 7 days
            dtpStartDate.Value = DateTime.Now.AddDays(-7);
            dtpEndDate.Value = DateTime.Now;
        }

        private void BtnGenerate_Click(object? sender, EventArgs e)
        {
            DateTime start = dtpStartDate.Value.Date;
            DateTime end = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1);

            var alerts = _alertRepo.GetAllAlerts().Where(a => a.AlertTime >= start && a.AlertTime <= end).ToList();
            var sensorData = _sensorRepo.GetRecentData(1000).Where(d => d.CreatedAt >= start && d.CreatedAt <= end).ToList();

            lblTotalAlerts.Text = alerts.Count.ToString();

            if (sensorData.Count > 0)
            {
                double max = sensorData.Max(d => d.LeakageCurrent);
                double avg = sensorData.Average(d => d.LeakageCurrent);

                lblMaxLeakage.Text = max.ToString("F2") + " mA";
                lblAvgLeakage.Text = avg.ToString("F2") + " mA";
            }
            else
            {
                lblMaxLeakage.Text = "0 mA";
                lblAvgLeakage.Text = "0 mA";
            }

            UpdatePieChart(alerts);
        }

        private void UpdatePieChart(List<WinformsDashboard.Models.Alert> alerts)
        {
            if (alerts.Count == 0)
            {
                pieChart.Series = new ISeries[0];
                return;
            }

            // Nhom canh bao theo thiet bi
            var alertGroups = alerts.GroupBy(a => a.DeviceID)
                                    .Select(g => new { DeviceID = g.Key, Count = g.Count() })
                                    .ToList();

            var series = new List<ISeries>();

            foreach (var group in alertGroups)
            {
                var device = _deviceRepo.GetDeviceById(group.DeviceID);
                string deviceName = device != null ? device.DeviceName : $"Thiết bị {group.DeviceID}";

                series.Add(new PieSeries<int>
                {
                    Values = new[] { group.Count },
                    Name = deviceName,
                    DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue} lần",
                    DataLabelsPaint = new SolidColorPaint(SKColors.White),
                    DataLabelsPosition = LiveChartsCore.Measure.PolarLabelsPosition.Outer,
                    DataLabelsSize = 12
                });
            }

            pieChart.Series = series;
            pieChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right;
        }

        private void lblAvgLeakage_Click(object sender, EventArgs e)
        {

        }
    }
}
