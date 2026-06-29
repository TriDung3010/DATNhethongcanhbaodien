using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WinformsDashboard.Models;

namespace WinformsDashboard.Services
{
    public class OllamaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _ollamaUrl = "http://localhost:11434/api/generate";
        private readonly string _modelName = "llama3";

        public OllamaService()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(60);
        }

        public async Task<AIPredictionResponse> GetPredictionAsync(List<SensorData> recentData)
        {
            if (recentData == null || recentData.Count == 0)
            {
                return new AIPredictionResponse
                {
                    RiskScore = 0,
                    RiskLevel = "Safe",
                    Prediction = "Không có dữ liệu để phân tích.",
                    Recommendation = "Đảm bảo thiết bị đang gửi dữ liệu."
                };
            }

            // Xây dựng chuỗi JSON từ danh sách dữ liệu
            var dataSummary = new StringBuilder();
            foreach (var d in recentData)
            {
                dataSummary.AppendLine($"Time: {d.CreatedAt:HH:mm:ss}, Voltage: {d.Voltage}V, Current: {d.CurrentValue}mA, Leakage: {d.LeakageCurrent}mA");
            }

            string prompt = $@"
Bạn là một chuyên gia phân tích an toàn điện năng. Hãy phân tích các bản ghi dữ liệu cảm biến gần đây của một thiết bị đo dòng điện rò. Ngưỡng rò rỉ nguy hiểm là > 30mA.
Dưới đây là 50 bản ghi dòng rò gần nhất:
{dataSummary.ToString()}

Yêu cầu:
Phân tích xu hướng dòng điện rò. BẮT BUỘC TRẢ LỜI BẰNG TIẾNG VIỆT (Vietnamese). Trả về MỘT chuỗi JSON duy nhất, KHÔNG chứa văn bản nào khác. Định dạng JSON như sau:
{{
  ""risk_score"": (số nguyên từ 0 đến 100 thể hiện mức độ nguy hiểm),
  ""risk_level"": (một trong 3 giá trị: ""An Toàn"", ""Cảnh Báo"", ""Nguy Hiểm""),
  ""prediction"": ""Mô tả ngắn gọn dự đoán của bạn về khả năng xảy ra rò điện sắp tới (bằng Tiếng Việt)"",
  ""recommendation"": ""Đề xuất hành động khắc phục (bằng Tiếng Việt)""
}}
Chỉ xuất đúng cú pháp JSON. Không Markdown, không giải thích.
";

            var requestBody = new
            {
                model = _modelName,
                prompt = prompt,
                stream = false,
                format = "json" // Yêu cầu trả về JSON chuẩn
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(_ollamaUrl, jsonContent);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                
                // Trích xuất JSON từ response của Ollama
                using (JsonDocument doc = JsonDocument.Parse(responseString))
                {
                    var root = doc.RootElement;
                    if (root.TryGetProperty("response", out var aiResponse))
                    {
                        string aiJsonText = aiResponse.GetString() ?? "{}";
                        var prediction = JsonSerializer.Deserialize<AIPredictionResponse>(aiJsonText);
                        return prediction ?? new AIPredictionResponse();
                    }
                }
            }
            catch (Exception ex)
            {
                return new AIPredictionResponse
                {
                    RiskScore = 0,
                    RiskLevel = "Error",
                    Prediction = "Lỗi kết nối tới AI.",
                    Recommendation = ex.Message
                };
            }

            return new AIPredictionResponse();
        }
        public async Task<PowerLossAIResponse> AnalyzePowerLossAsync(List<PowerLossRecord> recentData, double price)
        {
            if (recentData == null || recentData.Count == 0)
            {
                return new PowerLossAIResponse
                {
                    WasteLevel = "Low",
                    EstimatedMonthlyLoss = "0",
                    Recommendation = "Không có dữ liệu để phân tích."
                };
            }

            var dataSummary = new StringBuilder();
            foreach (var d in recentData)
            {
                dataSummary.AppendLine($"Time: {d.CreatedAt:HH:mm:ss}, PowerLoss: {d.PowerLoss:F2}W, Cost: {d.CostLoss:F2} VNĐ");
            }

            string prompt = $@"
Hãy phân tích dữ liệu thất thoát điện năng sau đây và đánh giá mức độ lãng phí điện, dự đoán xu hướng trong tương lai và đưa ra khuyến nghị tiết kiệm điện.
Giá điện hiện tại là {price} VNĐ/kWh.
Dữ liệu gần đây:
{dataSummary.ToString()}

Yêu cầu:
BẮT BUỘC TRẢ LỜI BẰNG TIẾNG VIỆT (Vietnamese). Trả về MỘT chuỗi JSON duy nhất, KHÔNG chứa văn bản nào khác. Định dạng JSON như sau:
{{
  ""waste_level"": (một trong các giá trị: ""Low"", ""Medium"", ""High""),
  ""estimated_monthly_loss"": ""Con số ước tính số tiền thất thoát mỗi tháng (VND)"",
  ""recommendation"": ""Đề xuất hành động khắc phục (bằng Tiếng Việt)""
}}
Chỉ xuất đúng cú pháp JSON. Không Markdown, không giải thích.
";

            var requestBody = new
            {
                model = _modelName,
                prompt = prompt,
                stream = false,
                format = "json"
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(_ollamaUrl, jsonContent);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                
                using (JsonDocument doc = JsonDocument.Parse(responseString))
                {
                    var root = doc.RootElement;
                    if (root.TryGetProperty("response", out var aiResponse))
                    {
                        string aiJsonText = aiResponse.GetString() ?? "{}";
                        var prediction = JsonSerializer.Deserialize<PowerLossAIResponse>(aiJsonText);
                        return prediction ?? new PowerLossAIResponse();
                    }
                }
            }
            catch (Exception ex)
            {
                return new PowerLossAIResponse
                {
                    WasteLevel = "Error",
                    EstimatedMonthlyLoss = "0",
                    Recommendation = "Lỗi kết nối tới AI: " + ex.Message
                };
            }

            return new PowerLossAIResponse();
        }
    }
}
