using Dapper;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using WinformsDashboard.Helpers;
using WinformsDashboard.Models;

namespace WinformsDashboard.DataAccess
{
    public class AlertRepository
    {
        public bool AddAlert(Alert alert)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Alerts (DeviceID, LeakageCurrent, AlertLevel, Description, AlertTime, IsResolved) VALUES (@DeviceID, @LeakageCurrent, @AlertLevel, @Description, @AlertTime, @IsResolved)";
                if (alert.AlertTime == default) alert.AlertTime = DateTime.Now;
                return db.Execute(query, alert) > 0;
            }
        }

        public List<Alert> GetAllAlerts(DateTime? fromDate = null, DateTime? toDate = null)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Alerts WHERE 1=1";
                if (fromDate.HasValue) query += " AND AlertTime >= @FromDate";
                if (toDate.HasValue) query += " AND AlertTime <= @ToDate";
                query += " ORDER BY AlertTime DESC";
                
                return db.Query<Alert>(query, new { FromDate = fromDate, ToDate = toDate }).ToList();
            }
        }

        public bool ResolveAlert(int alertId)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Alerts SET IsResolved = 1 WHERE AlertID = @AlertID";
                return db.Execute(query, new { AlertID = alertId }) > 0;
            }
        }
        
        public int GetTodayAlertCount()
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Alerts WHERE CONVERT(date, AlertTime) = CONVERT(date, GETDATE())";
                return db.QuerySingle<int>(query);
            }
        }
    }
}
