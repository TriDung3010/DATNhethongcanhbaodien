using System.Text.Json.Serialization;

namespace WinformsDashboard.Models
{
    public class PowerLossAIResponse
    {
        [JsonPropertyName("waste_level")]
        public string WasteLevel { get; set; } = string.Empty;

        [JsonPropertyName("estimated_monthly_loss")]
        public string EstimatedMonthlyLoss { get; set; } = string.Empty;

        [JsonPropertyName("recommendation")]
        public string Recommendation { get; set; } = string.Empty;
    }
}
