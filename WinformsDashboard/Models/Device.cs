namespace WinformsDashboard.Models
{
    public class Device
    {
        public int DeviceID { get; set; }
        public string DeviceCode { get; set; } = string.Empty;
        public string DeviceName { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string IPAddress { get; set; } = string.Empty;
        public string Status { get; set; } = "Online";
    }
}
