using PersonalFinanceManager.Data;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Services
{
    public class AuthService
    {
        private readonly JsonDataService _dataService;

        public AuthService()
        {
            _dataService = new JsonDataService();
        }

        public bool Register(string fullName, string username, string password, out string message)
        {
            fullName = fullName.Trim();
            username = username.Trim();
            password = password.Trim();

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                message = "Toate câmpurile sunt obligatorii.";
                return false;
            }

            List<User> users = _dataService.LoadUsers();

            bool userExists = users.Any(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (userExists)
            {
                message = "Există deja un utilizator cu acest username.";
                return false;
            }

            int newId = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;

            User newUser = new User
            {
                Id = newId,
                FullName = fullName,
                Username = username,
                Password = password
            };

            users.Add(newUser);
            _dataService.SaveUsers(users);

            message = "Cont creat cu succes.";
            return true;
        }

        public User? Login(string username, string password, out string message)
        {
            username = username.Trim();
            password = password.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                message = "Username și parola sunt obligatorii.";
                return null;
            }

            List<User> users = _dataService.LoadUsers();

            User? user = users.FirstOrDefault(u =>
                u.Username.Equals(username, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);

            if (user == null)
            {
                message = "Username sau parolă greșită.";
                return null;
            }

            message = "Autentificare reușită.";
            return user;
        }
    }
}