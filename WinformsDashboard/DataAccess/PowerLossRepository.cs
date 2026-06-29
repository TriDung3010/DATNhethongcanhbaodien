using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WinformsDashboard.Helpers;
using WinformsDashboard.Models;

namespace WinformsDashboard.DataAccess
{
    public class PowerLossRepository
    {
        public PowerLossRepository()
        {
            EnsureTablesCreated();
        }

        private void EnsureTablesCreated()
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string createConfigQuery = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='ElectricityConfig' AND xtype='U')
                    BEGIN
                        CREATE TABLE ElectricityConfig (
                            ConfigID INT PRIMARY KEY IDENTITY,
                            ElectricityPrice FLOAT,
                            UpdatedAt DATETIME DEFAULT GETDATE()
                        );
                        INSERT INTO ElectricityConfig (ElectricityPrice) VALUES (3000);
                    END";
                db.Execute(createConfigQuery);

                string createLossQuery = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='PowerLossHistory' AND xtype='U')
                    BEGIN
                        CREATE TABLE PowerLossHistory (
                            LossID INT PRIMARY KEY IDENTITY,
                            DeviceID INT,
                            Voltage FLOAT,
                            LeakageCurrent FLOAT,
                            PowerLoss FLOAT,
                            EnergyLoss FLOAT,
                            CostLoss FLOAT,
                            CreatedAt DATETIME DEFAULT GETDATE()
                        );
                    END";
                db.Execute(createLossQuery);
            }
        }
        public bool AddRecord(PowerLossRecord record)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = @"INSERT INTO PowerLossHistory (DeviceID, Voltage, LeakageCurrent, PowerLoss, EnergyLoss, CostLoss, CreatedAt)
                                 VALUES (@DeviceID, @Voltage, @LeakageCurrent, @PowerLoss, @EnergyLoss, @CostLoss, @CreatedAt)";
                if (record.CreatedAt == default) record.CreatedAt = DateTime.Now;
                return db.Execute(query, record) > 0;
            }
        }

        public List<PowerLossRecord> GetAllRecords()
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                return db.Query<PowerLossRecord>("SELECT * FROM PowerLossHistory ORDER BY CreatedAt DESC").ToList();
            }
        }

        public double GetTodayEnergyLoss()
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "SELECT SUM(EnergyLoss) FROM PowerLossHistory WHERE CONVERT(date, CreatedAt) = CONVERT(date, GETDATE())";
                return db.QuerySingleOrDefault<double?>(query) ?? 0;
            }
        }

        public double GetTodayCostLoss()
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "SELECT SUM(CostLoss) FROM PowerLossHistory WHERE CONVERT(date, CreatedAt) = CONVERT(date, GETDATE())";
                return db.QuerySingleOrDefault<double?>(query) ?? 0;
            }
        }

        public double GetCurrentMonthCostLoss()
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "SELECT SUM(CostLoss) FROM PowerLossHistory WHERE MONTH(CreatedAt) = MONTH(GETDATE()) AND YEAR(CreatedAt) = YEAR(GETDATE())";
                return db.QuerySingleOrDefault<double?>(query) ?? 0;
            }
        }

        public PowerLossRecord? GetLatestRecord()
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                return db.QueryFirstOrDefault<PowerLossRecord>("SELECT TOP 1 * FROM PowerLossHistory ORDER BY CreatedAt DESC");
            }
        }

        public List<dynamic> GetEnergyLossByDay(int days = 7)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT CONVERT(date, CreatedAt) as Date, SUM(EnergyLoss) as TotalEnergy
                    FROM PowerLossHistory
                    WHERE CreatedAt >= DATEADD(day, -@Days, GETDATE())
                    GROUP BY CONVERT(date, CreatedAt)
                    ORDER BY CONVERT(date, CreatedAt)";
                return db.Query(query, new { Days = days }).ToList();
            }
        }
        
        public List<dynamic> GetCostLossByMonth(int months = 6)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT FORMAT(CreatedAt, 'yyyy-MM') as Month, SUM(CostLoss) as TotalCost
                    FROM PowerLossHistory
                    WHERE CreatedAt >= DATEADD(month, -@Months, GETDATE())
                    GROUP BY FORMAT(CreatedAt, 'yyyy-MM')
                    ORDER BY FORMAT(CreatedAt, 'yyyy-MM')";
                return db.Query(query, new { Months = months }).ToList();
            }
        }

        public List<dynamic> GetTopWastingDevices()
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = @"
                    SELECT d.DeviceName, SUM(p.CostLoss) as TotalCost
                    FROM PowerLossHistory p
                    JOIN Devices d ON p.DeviceID = d.DeviceID
                    GROUP BY d.DeviceName
                    ORDER BY TotalCost DESC";
                return db.Query(query).ToList();
            }
        }
    }
}
