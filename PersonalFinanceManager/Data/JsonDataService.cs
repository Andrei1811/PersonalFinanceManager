using System.Text.Json;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Data
{
    public class JsonDataService
    {
        private readonly string _dataFolder;
        private readonly string _usersFile;
        private readonly string _categoriesFile;
        private readonly string _incomesFile;
        private readonly string _expensesFile;

        public JsonDataService()
        {
            _dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Storage");
            _usersFile = Path.Combine(_dataFolder, "users.json");
            _categoriesFile = Path.Combine(_dataFolder, "categories.json");
            _incomesFile = Path.Combine(_dataFolder, "incomes.json");
            _expensesFile = Path.Combine(_dataFolder, "expenses.json");

            CreateFilesIfNeeded();
        }

        private void CreateFilesIfNeeded()
        {
            if (!Directory.Exists(_dataFolder))
            {
                Directory.CreateDirectory(_dataFolder);
            }

            CreateFileIfMissing(_usersFile);
            CreateFileIfMissing(_categoriesFile);
            CreateFileIfMissing(_incomesFile);
            CreateFileIfMissing(_expensesFile);
        }

        private void CreateFileIfMissing(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, "[]");
            }
        }

        public List<User> LoadUsers()
        {
            return ReadList<User>(_usersFile);
        }

        public void SaveUsers(List<User> users)
        {
            WriteList(_usersFile, users);
        }

        public List<Category> LoadCategories()
        {
            return ReadList<Category>(_categoriesFile);
        }

        public void SaveCategories(List<Category> categories)
        {
            WriteList(_categoriesFile, categories);
        }

        public List<Income> LoadIncomes()
        {
            return ReadList<Income>(_incomesFile);
        }

        public void SaveIncomes(List<Income> incomes)
        {
            WriteList(_incomesFile, incomes);
        }

        public List<Expense> LoadExpenses()
        {
            return ReadList<Expense>(_expensesFile);
        }

        public void SaveExpenses(List<Expense> expenses)
        {
            WriteList(_expensesFile, expenses);
        }

        public AppData LoadAllData()
        {
            return new AppData
            {
                Users = LoadUsers(),
                Categories = LoadCategories(),
                Incomes = LoadIncomes(),
                Expenses = LoadExpenses()
            };
        }

        public void SaveAllData(AppData data)
        {
            SaveUsers(data.Users);
            SaveCategories(data.Categories);
            SaveIncomes(data.Incomes);
            SaveExpenses(data.Expenses);
        }

        private List<T> ReadList<T>(string filePath)
        {
            string json = File.ReadAllText(filePath);

            List<T>? data = JsonSerializer.Deserialize<List<T>>(json);

            return data ?? new List<T>();
        }

        private void WriteList<T>(string filePath, List<T> data)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(data, options);
            File.WriteAllText(filePath, json);
        }
    }
}