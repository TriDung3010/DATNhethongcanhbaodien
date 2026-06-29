using System;

namespace WinformsDashboard.Models
{
    public class PowerLossRecord
    {
        public int LossID { get; set; }
        public int DeviceID { get; set; }
        public double Voltage { get; set; }
        public double LeakageCurrent { get; set; }
        
        // Công suất thất thoát (W) = Voltage * LeakageCurrent
        public double PowerLoss { get; set; }
        
        // Điện năng thất thoát (kWh) = (PowerLoss * TimeHours) / 1000
        public double EnergyLoss { get; set; }
        
        // Chi phí thất thoát = EnergyLoss * ElectricityPrice
        public double CostLoss { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
}
