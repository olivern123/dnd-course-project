using WasteTracker.Web.Models;

namespace WasteTracker.Web.Services
{
    public class AuthService
    {
        public User? CurrentUser { get; private set; }

        public bool IsLoggedIn => CurrentUser != null;
        public bool IsAdmin => CurrentUser?.Role == "Admin";

        public void SetUser(User user)
        {
            CurrentUser = user;
            Console.WriteLine($"[AuthService] User set to: {user.Username} (IsLoggedIn={IsLoggedIn})");
        }

        public void Logout()
        {
            CurrentUser = null;
            Console.WriteLine($"[AuthService] User logged out");
        }
    }
}
