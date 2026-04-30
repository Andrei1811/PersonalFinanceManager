using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Services
{
    public static class SessionManager
    {
        public static User? CurrentUser { get; private set; }

        public static void Login(User user)
        {
            CurrentUser = user;
        }

        public static void Logout()
        {
            CurrentUser = null;
        }
    }
}