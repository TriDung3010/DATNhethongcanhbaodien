using System;
using System.Drawing;
using System.Windows.Forms;
using WinformsDashboard.DataAccess;
using WinformsDashboard.Services;

namespace WinformsDashboard.Forms
{
    public partial class AIPredictionForm : Form
    {
        private readonly OllamaService _ollamaService;
        private readonly SensorDataRepository _sensorRepo;

        public AIPredictionForm()
        {
            InitializeComponent();
            _ollamaService = new OllamaService();
            _sensorRepo = new SensorDataRepository();
        }

        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            btnAnalyze.Enabled = false;
            btnAnalyze.Text = "Đang phân tích...";

            try
            {
                // Lấy 50 bản ghi gần nhất
                var recentData = _sensorRepo.GetRecentData(50);
                
                // Gọi API
                var prediction = await _ollamaService.GetPredictionAsync(recentData);

                // Hiển thị kết quả
                lblRiskScore.Text = $"{prediction.RiskScore}%";
                lblRiskLevel.Text = prediction.RiskLevel;
                txtPrediction.Text = prediction.Prediction;
                txtRecommendation.Text = prediction.Recommendation;

                // Xử lý màu sắc
                Color riskColor;
                if (prediction.RiskScore > 80)
                {
                    riskColor = Color.Red;
                    MessageBox.Show($"Cảnh báo AI: {prediction.Prediction}", "AI Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (prediction.RiskScore >= 50)
                {
                    riskColor = Color.Orange;
                }
                else
                {
                    riskColor = Color.Green;
                }

                lblRiskScore.ForeColor = riskColor;
                lblRiskLevel.ForeColor = riskColor;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi phân tích: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAnalyze.Enabled = true;
                btnAnalyze.Text = "Chạy Phân Tích AI";
            }
        }
    }
}
