using Dapper;
using System.Linq;
using WinformsDashboard.Helpers;
using WinformsDashboard.Models;

namespace WinformsDashboard.DataAccess
{
    public class ConfigRepository
    {
        public ConfigRepository()
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
            }
        }

        public ElectricityConfig GetCurrentConfig()
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "SELECT TOP 1 * FROM ElectricityConfig ORDER BY UpdatedAt DESC";
                return db.Query<ElectricityConfig>(query).FirstOrDefault() ?? new ElectricityConfig { ElectricityPrice = 3000 };
            }
        }

        public double GetElectricityPrice()
        {
            return GetCurrentConfig().ElectricityPrice;
        }

        public bool UpdateElectricityPrice(double newPrice)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO ElectricityConfig (ElectricityPrice, UpdatedAt) VALUES (@Price, GETDATE())";
                return db.Execute(query, new { Price = newPrice }) > 0;
            }
        }
    }
}
