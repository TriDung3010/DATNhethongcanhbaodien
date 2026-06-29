using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using WinformsDashboard.DataAccess;
using WinformsDashboard.Models;
using WinformsDashboard.Services;

namespace WinformsDashboard.Forms
{
    public partial class PowerLossAnalysisForm : Form
    {
        private readonly PowerLossRepository _powerLossRepo;
        private readonly ConfigRepository _configRepo;
        private readonly OllamaService _ollamaService;
        private readonly ReportExportService _exportService;
        
        private PowerLossAIResponse? _lastAiResponse = null;

        public PowerLossAnalysisForm()
        {
            InitializeComponent();
            
            

            
            _powerLossRepo = new PowerLossRepository();
            _configRepo = new ConfigRepository();
            _ollamaService = new OllamaService();
            _exportService = new ReportExportService();

            this.Load += PowerLossAnalysisForm_Load;
            
            btnAI.Click += BtnAI_Click;
            btnExportExcel.Click += BtnExportExcel_Click;
            btnExportPdf.Click += BtnExportPdf_Click;
            btnConfigPrice.Click += BtnConfigPrice_Click;
            
            // Subscribe to real-time updates
            IoTService.Instance.OnDataReceived += OnDataReceived;
        }

        private void OnDataReceived(object? sender, SensorData e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => LoadData()));
            }
            else
            {
                LoadData();
            }
        }

        private void PowerLossAnalysisForm_Load(object? sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // Cards
            var latest = _powerLossRepo.GetLatestRecord();
            if (latest != null)
            {
                lblCurrentLoss.Text = $"{latest.PowerLoss:F2} W";
            }
            
            lblTodayEnergy.Text = $"{_powerLossRepo.GetTodayEnergyLoss():F4} kWh";
            lblTodayCost.Text = $"{_powerLossRepo.GetTodayCostLoss():N0} VNĐ";
            lblMonthCost.Text = $"{_powerLossRepo.GetCurrentMonthCostLoss():N0} VNĐ";

            // Grid
            var allRecords = _powerLossRepo.GetAllRecords();
            dgvDetails.DataSource = allRecords;

            // Charts
            LoadCharts();
        }

        private void LoadCharts()
        {
            // Chart 1: Energy Loss by Day
            var energyByDay = _powerLossRepo.GetEnergyLossByDay(7);
            var energyValues = new List<double>();
            var energyLabels = new List<string>();
            foreach (var item in energyByDay)
            {
                energyLabels.Add(((DateTime)item.Date).ToString("dd/MM"));
                energyValues.Add((double)item.TotalEnergy);
            }

            chartEnergy.Series = new ISeries[]
            {
                new ColumnSeries<double>
                {
                    Values = energyValues,
                    Name = "Điện Năng (kWh)",
                    Fill = new SolidColorPaint(SKColors.Orange)
                }
            };
            chartEnergy.XAxes = new Axis[] { new Axis { Labels = energyLabels } };

            // Chart 2: Cost Loss by Month
            var costByMonth = _powerLossRepo.GetCostLossByMonth(6);
            var costValues = new List<double>();
            var costLabels = new List<string>();
            foreach (var item in costByMonth)
            {
                costLabels.Add((string)item.Month);
                costValues.Add((double)item.TotalCost);
            }

            chartCost.Series = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = costValues,
                    Name = "Chi Phí (VNĐ)",
                    Stroke = new SolidColorPaint(SKColors.Red) { StrokeThickness = 3 },
                    Fill = null
                }
            };
            chartCost.XAxes = new Axis[] { new Axis { Labels = costLabels } };
        }

        private async void BtnAI_Click(object? sender, EventArgs e)
        {
            btnAI.Enabled = false;
            btnAI.Text = "Đang phân tích...";
            lblAIResult.Text = "Ollama đang phân tích dữ liệu...";

            try
            {
                var recentData = _powerLossRepo.GetAllRecords();
                if (recentData.Count > 50) recentData = recentData.GetRange(0, 50); // Get last 50
                double price = _configRepo.GetElectricityPrice();
                
                _lastAiResponse = await _ollamaService.AnalyzePowerLossAsync(recentData, price);
                
                lblAIResult.Text = $"Mức độ: {_lastAiResponse.WasteLevel} | Dự kiến mất: {_lastAiResponse.EstimatedMonthlyLoss} VNĐ\nĐề xuất: {_lastAiResponse.Recommendation}";
                
                if (_lastAiResponse.WasteLevel == "High")
                    lblAIResult.ForeColor = Color.Red;
                else if (_lastAiResponse.WasteLevel == "Medium")
                    lblAIResult.ForeColor = Color.Orange;
                else
                    lblAIResult.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi phân tích AI: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblAIResult.Text = "Lỗi phân tích AI.";
            }
            finally
            {
                btnAI.Enabled = true;
                btnAI.Text = "🤖 Phân Tích AI";
            }
        }

        private async void BtnExportExcel_Click(object? sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var records = _powerLossRepo.GetAllRecords();
                    await _exportService.ExportToExcelAsync(sfd.FileName, records, _lastAiResponse);
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void BtnExportPdf_Click(object? sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF Document|*.pdf" })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var records = _powerLossRepo.GetAllRecords();
                    await _exportService.ExportToPdfAsync(sfd.FileName, records, _lastAiResponse);
                    MessageBox.Show("Xuất PDF thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnConfigPrice_Click(object? sender, EventArgs e)
        {
            string currentPrice = _configRepo.GetElectricityPrice().ToString();
            string input = Microsoft.VisualBasic.Interaction.InputBox("Nhập giá điện mới (VNĐ/kWh):", "Cài đặt giá điện", currentPrice);
            if (double.TryParse(input, out double newPrice))
            {
                _configRepo.UpdateElectricityPrice(newPrice);
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
        }
    }
}
