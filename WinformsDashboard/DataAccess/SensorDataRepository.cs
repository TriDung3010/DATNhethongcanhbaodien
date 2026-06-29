using Dapper;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using WinformsDashboard.Helpers;
using WinformsDashboard.Models;

namespace WinformsDashboard.DataAccess
{
    public class SensorDataRepository
    {
        public bool AddSensorData(SensorData data)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO SensorData (DeviceID, Voltage, CurrentValue, LeakageCurrent, CreatedAt) VALUES (@DeviceID, @Voltage, @CurrentValue, @LeakageCurrent, @CreatedAt)";
                // Nếu CreatedAt chưa được gán, dùng thời gian hiện tại
                if (data.CreatedAt == default) data.CreatedAt = DateTime.Now;
                return db.Execute(query, data) > 0;
            }
        }

        public List<SensorData> GetHistory(DateTime fromDate, DateTime toDate, int deviceId = 0)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM SensorData WHERE CreatedAt >= @FromDate AND CreatedAt <= @ToDate";
                if (deviceId > 0)
                {
                    query += " AND DeviceID = @DeviceID";
                }
                query += " ORDER BY CreatedAt DESC";
                return db.Query<SensorData>(query, new { FromDate = fromDate, ToDate = toDate, DeviceID = deviceId }).ToList();
            }
        }
        
        public List<SensorData> GetRecentData(int count = 50)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = $"SELECT TOP {count} * FROM SensorData ORDER BY CreatedAt DESC";
                return db.Query<SensorData>(query).ToList();
            }
        }
    }
}
