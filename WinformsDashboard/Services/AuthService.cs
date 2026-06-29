using WinformsDashboard.DataAccess;
using WinformsDashboard.Helpers;
using WinformsDashboard.Models;

namespace WinformsDashboard.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepo = new UserRepository();

        public static User? CurrentUser { get; private set; }

        public bool Login(string username, string password)
        {
            var user = _userRepo.GetUserByUsername(username);
            if (user != null)
            {
                // Nếu mật khẩu trong DB đang là mã giả (dummy) từ file script
                if (user.PasswordHash.Contains("wK1F5N8Kk.zF0z9tE.9F/el.mG5Jq7o1M.jD4/g9cM/0aU9/z/KjG"))
                {
                    if (password == "admin123" && username == "admin")
                    {
                        // Cập nhật lại mật khẩu thật vào Database để lần sau dùng bình thường
                        _userRepo.UpdatePassword(user.UserID, PasswordHasher.HashPassword("admin123"));
                        CurrentUser = user;
                        return true;
                    }
                }

                if (PasswordHasher.VerifyPassword(password, user.PasswordHash))
                {
                    CurrentUser = user;
                    return true;
                }
            }
            return false;
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}
