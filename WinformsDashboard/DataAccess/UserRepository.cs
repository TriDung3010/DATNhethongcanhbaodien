using Dapper;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using WinformsDashboard.Helpers;
using WinformsDashboard.Models;

namespace WinformsDashboard.DataAccess
{
    public class UserRepository
    {
        public User? GetUserByUsername(string username)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Users WHERE Username = @Username";
                return db.QueryFirstOrDefault<User>(query, new { Username = username });
            }
        }

        public List<User> GetAllUsers()
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "SELECT * FROM Users";
                return db.Query<User>(query).ToList();
            }
        }

        public bool AddUser(User user)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "INSERT INTO Users (Username, PasswordHash, Role) VALUES (@Username, @PasswordHash, @Role)";
                int rows = db.Execute(query, user);
                return rows > 0;
            }
        }

        public bool UpdateUserRole(int userId, string role)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Users SET Role = @Role WHERE UserID = @UserID";
                int rows = db.Execute(query, new { Role = role, UserID = userId });
                return rows > 0;
            }
        }

        public bool UpdatePassword(int userId, string passwordHash)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "UPDATE Users SET PasswordHash = @PasswordHash WHERE UserID = @UserID";
                int rows = db.Execute(query, new { PasswordHash = passwordHash, UserID = userId });
                return rows > 0;
            }
        }

        public bool DeleteUser(int userId)
        {
            using (var db = DatabaseConnection.GetConnection())
            {
                string query = "DELETE FROM Users WHERE UserID = @UserID";
                int rows = db.Execute(query, new { UserID = userId });
                return rows > 0;
            }
        }
    }
}
