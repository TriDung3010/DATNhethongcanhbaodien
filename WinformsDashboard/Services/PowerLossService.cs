using System;
using WinformsDashboard.DataAccess;
using WinformsDashboard.Models;

namespace WinformsDashboard.Services
{
    public class PowerLossService
    {
        public static PowerLossService Instance { get; } = new PowerLossService();

        private readonly PowerLossRepository _powerLossRepo;
        private readonly ConfigRepository _configRepo;

        // Interval data is sent from ESP32 is 3 seconds
        private const double INTERVAL_SECONDS = 3.0;

        private PowerLossService()
        {
            _powerLossRepo = new PowerLossRepository();
            _configRepo = new ConfigRepository();
        }

        public void Initialize()
        {
            IoTService.Instance.OnDataReceived += OnDataReceived;
        }

        private void OnDataReceived(object? sender, SensorData data)
        {
            // Calculate Power Loss
            // Voltage (V), LeakageCurrent is in mA, so convert to A
            double currentA = data.LeakageCurrent / 1000.0;
            double powerLossW = data.Voltage * currentA;

            // Calculate Energy Loss (kWh)
            // Energy = Power(W) * Time(h) / 1000
            double timeHours = INTERVAL_SECONDS / 3600.0;
            double energyLossKwh = (powerLossW * timeHours) / 1000.0;

            // Calculate Cost Loss
            double pricePerKwh = _configRepo.GetElectricityPrice();
            double costLoss = energyLossKwh * pricePerKwh;

            var record = new PowerLossRecord
            {
                DeviceID = data.DeviceID,
                Voltage = data.Voltage,
                LeakageCurrent = data.LeakageCurrent,
                PowerLoss = powerLossW,
                EnergyLoss = energyLossKwh,
                CostLoss = costLoss,
                CreatedAt = data.CreatedAt
            };

            _powerLossRepo.AddRecord(record);
        }
    }
}
