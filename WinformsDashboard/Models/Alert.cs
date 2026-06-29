using System;

namespace WinformsDashboard.Models
{
    public class Alert
    {
        public int AlertID { get; set; }
        public int DeviceID { get; set; }
        public double LeakageCurrent { get; set; }
        public string AlertLevel { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime AlertTime { get; set; }
        public bool IsResolved { get; set; }
    }
}
