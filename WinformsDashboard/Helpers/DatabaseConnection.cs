using Microsoft.Data.SqlClient;

namespace WinformsDashboard.Helpers
{
    public static class DatabaseConnection
    {
        // Thay đổi Connection String tương ứng với máy tính
        private static readonly string _connectionString = "Server=NgoViHao\\SQLEXPRESS;Database=IoTLeakageDB;Trusted_Connection=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
