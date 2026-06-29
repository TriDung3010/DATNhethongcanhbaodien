using System;

namespace WinformsDashboard.Models
{
    public class ElectricityConfig
    {
        public int ConfigID { get; set; }
        public double ElectricityPrice { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
