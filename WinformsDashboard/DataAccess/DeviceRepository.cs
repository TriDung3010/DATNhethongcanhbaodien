using Dapper;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using WinformsDashboard.Helpers;
using WinformsDashboard.Models;

namespace WinformsDashboard.DataAccess
{
    public class DeviceRepository
    {
        public List<Device> GetAllDevices()
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                return db.Query<Device>("SELECT * FROM Devices").ToList();
            }
        }

        public Device? GetDeviceByCode(string deviceCode)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                return db.QueryFirstOrDefault<Device>("SELECT * FROM Devices WHERE DeviceCode = @DeviceCode", new { DeviceCode = deviceCode });
            }
        }

        public Device? GetDeviceById(int deviceId)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                return db.QueryFirstOrDefault<Device>("SELECT * FROM Devices WHERE DeviceID = @DeviceID", new { DeviceID = deviceId });
            }
        }

        public bool AddDevice(Device device)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Devices (DeviceCode, DeviceName, Location, IPAddress, Status) VALUES (@DeviceCode, @DeviceName, @Location, @IPAddress, @Status)";
                return db.Execute(query, device) > 0;
            }
        }

        public bool UpdateDevice(Device device)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Devices SET DeviceCode = @DeviceCode, DeviceName = @DeviceName, Location = @Location, IPAddress = @IPAddress, Status = @Status WHERE DeviceID = @DeviceID";
                return db.Execute(query, device) > 0;
            }
        }

        public bool DeleteDevice(int deviceId)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                return db.Execute("DELETE FROM Devices WHERE DeviceID = @DeviceID", new { DeviceID = deviceId }) > 0;
            }
        }
    }
}
