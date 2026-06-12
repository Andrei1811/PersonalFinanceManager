using PersonalFinanceManager.Data;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Services
{
    public class BudgetService
    {
        private readonly JsonDataService _dataService;

        public BudgetService()
        {
            _dataService = new JsonDataService();
        }

        public MonthlyBudget? GetBudget(int userId, int year, int month)
        {
            List<MonthlyBudget> budgets = _dataService.LoadMonthlyBudgets();

            return budgets.FirstOrDefault(b =>
                b.UserId == userId &&
                b.Year == year &&
                b.Month == month);
        }

        public decimal GetBudgetAmount(int userId, int year, int month)
        {
            MonthlyBudget? budget = GetBudget(userId, year, month);

            if (budget == null)
            {
                return 0;
            }

            return budget.Amount;
        }

        public void SaveBudget(int userId, int year, int month, decimal amount)
        {
            List<MonthlyBudget> budgets = _dataService.LoadMonthlyBudgets();

            MonthlyBudget? existingBudget = budgets.FirstOrDefault(b =>
                b.UserId == userId &&
                b.Year == year &&
                b.Month == month);

            if (existingBudget == null)
            {
                MonthlyBudget newBudget = new MonthlyBudget
                {
                    UserId = userId,
                    Year = year,
                    Month = month,
                    Amount = amount
                };

                budgets.Add(newBudget);
            }
            else
            {
                existingBudget.Amount = amount;
            }

            _dataService.SaveMonthlyBudgets(budgets);
        }
    }
}