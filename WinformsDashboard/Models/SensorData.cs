using System;

namespace WinformsDashboard.Models
{
    public class SensorData
    {
        public int DataID { get; set; }
        public int DeviceID { get; set; }
        public double Voltage { get; set; }
        public double CurrentValue { get; set; }
        public double LeakageCurrent { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
