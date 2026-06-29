using System;
using System.Text.Json.Serialization;

namespace WinformsDashboard.Models
{
    public class AIPredictionResponse
    {
        [JsonPropertyName("risk_score")]
        public int RiskScore { get; set; }

        [JsonPropertyName("risk_level")]
        public string RiskLevel { get; set; }

        [JsonPropertyName("prediction")]
        public string Prediction { get; set; }

        [JsonPropertyName("recommendation")]
        public string Recommendation { get; set; }
    }
}
