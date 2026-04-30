using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Data
{
    public class AppData
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<Category> Categories { get; set; } = new List<Category>();
        public List<Income> Incomes { get; set; } = new List<Income>();
        public List<Expense> Expenses { get; set; } = new List<Expense>();
    }
}