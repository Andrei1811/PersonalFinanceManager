using PersonalFinanceManager.Data;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Services
{
    public class TransactionService
    {
        private readonly JsonDataService _dataService;

        public TransactionService()
        {
            _dataService = new JsonDataService();
        }

        public List<TransactionListItem> GetTransactionListItems(int? userId = null)
        {
            List<Income> incomes = _dataService.LoadIncomes();
            List<Expense> expenses = _dataService.LoadExpenses();
            List<Category> categories = _dataService.LoadCategories();

            List<TransactionListItem> result = new List<TransactionListItem>();

            foreach (Income income in incomes)
            {
                if (userId.HasValue && income.UserId != userId.Value)
                    continue;

                string categoryName = GetCategoryName(categories, income.CategoryId);

                result.Add(new TransactionListItem
                {
                    Id = income.Id,
                    Type = "Income",
                    Title = income.Title,
                    Category = categoryName,
                    Amount = income.Amount,
                    Date = income.Date.ToString("yyyy-MM-dd")
                });
            }

            foreach (Expense expense in expenses)
            {
                if (userId.HasValue && expense.UserId != userId.Value)
                    continue;

                string categoryName = GetCategoryName(categories, expense.CategoryId);

                result.Add(new TransactionListItem
                {
                    Id = expense.Id,
                    Type = "Expense",
                    Title = expense.Title,
                    Category = categoryName,
                    Amount = expense.Amount,
                    Date = expense.Date.ToString("yyyy-MM-dd")
                });
            }

            return result.OrderBy(x => x.Id).ToList();
        }

        public bool AddTransaction(TransactionListItem item, int userId, out string message)
        {
            List<Category> categories = _dataService.LoadCategories();

            Category? category = categories.FirstOrDefault(c =>
                c.Name.Equals(item.Category, StringComparison.OrdinalIgnoreCase) &&
                c.Type.Equals(item.Type, StringComparison.OrdinalIgnoreCase));

            if (category == null)
            {
                message = "Categoria nu există în categories.json pentru tipul selectat.";
                return false;
            }

            if (item.Type.Equals("Income", StringComparison.OrdinalIgnoreCase))
            {
                List<Income> incomes = _dataService.LoadIncomes();

                int newId = incomes.Count > 0 ? incomes.Max(x => x.Id) + 1 : 1;

                Income newIncome = new Income
                {
                    Id = newId,
                    UserId = userId,
                    Title = item.Title,
                    Amount = item.Amount,
                    Date = DateTime.Parse(item.Date),
                    CategoryId = category.Id
                };

                incomes.Add(newIncome);
                _dataService.SaveIncomes(incomes);

                message = "Venitul a fost salvat cu succes.";
                return true;
            }

            if (item.Type.Equals("Expense", StringComparison.OrdinalIgnoreCase))
            {
                List<Expense> expenses = _dataService.LoadExpenses();

                int newId = expenses.Count > 0 ? expenses.Max(x => x.Id) + 1 : 1;

                Expense newExpense = new Expense
                {
                    Id = newId,
                    UserId = userId,
                    Title = item.Title,
                    Amount = item.Amount,
                    Date = DateTime.Parse(item.Date),
                    CategoryId = category.Id
                };

                expenses.Add(newExpense);
                _dataService.SaveExpenses(expenses);

                message = "Cheltuiala a fost salvată cu succes.";
                return true;
            }

            message = "Tipul tranzacției este invalid.";
            return false;
        }

        public bool UpdateTransaction(TransactionListItem item, int userId, out string message)
        {
            List<Category> categories = _dataService.LoadCategories();

            Category? category = categories.FirstOrDefault(c =>
                c.Name.Equals(item.Category, StringComparison.OrdinalIgnoreCase) &&
                c.Type.Equals(item.Type, StringComparison.OrdinalIgnoreCase));

            if (category == null)
            {
                message = "Categoria nu există în categories.json pentru tipul selectat.";
                return false;
            }

            if (item.Type.Equals("Income", StringComparison.OrdinalIgnoreCase))
            {
                List<Income> incomes = _dataService.LoadIncomes();

                Income? incomeToUpdate = incomes.FirstOrDefault(x => x.Id == item.Id && x.UserId == userId);

                if (incomeToUpdate == null)
                {
                    message = "Venitul nu a fost găsit.";
                    return false;
                }

                incomeToUpdate.Title = item.Title;
                incomeToUpdate.Amount = item.Amount;
                incomeToUpdate.Date = DateTime.Parse(item.Date);
                incomeToUpdate.CategoryId = category.Id;

                _dataService.SaveIncomes(incomes);

                message = "Venitul a fost actualizat cu succes.";
                return true;
            }

            if (item.Type.Equals("Expense", StringComparison.OrdinalIgnoreCase))
            {
                List<Expense> expenses = _dataService.LoadExpenses();

                Expense? expenseToUpdate = expenses.FirstOrDefault(x => x.Id == item.Id && x.UserId == userId);

                if (expenseToUpdate == null)
                {
                    message = "Cheltuiala nu a fost găsită.";
                    return false;
                }

                expenseToUpdate.Title = item.Title;
                expenseToUpdate.Amount = item.Amount;
                expenseToUpdate.Date = DateTime.Parse(item.Date);
                expenseToUpdate.CategoryId = category.Id;

                _dataService.SaveExpenses(expenses);

                message = "Cheltuiala a fost actualizată cu succes.";
                return true;
            }

            message = "Tipul tranzacției este invalid.";
            return false;
        }

        public bool DeleteTransaction(int transactionId, string transactionType, int userId, out string message)
        {
            if (transactionType.Equals("Income", StringComparison.OrdinalIgnoreCase))
            {
                List<Income> incomes = _dataService.LoadIncomes();

                Income? incomeToDelete = incomes.FirstOrDefault(x => x.Id == transactionId && x.UserId == userId);

                if (incomeToDelete == null)
                {
                    message = "Venitul nu a fost găsit.";
                    return false;
                }

                incomes.Remove(incomeToDelete);
                _dataService.SaveIncomes(incomes);

                message = "Venitul a fost șters cu succes.";
                return true;
            }

            if (transactionType.Equals("Expense", StringComparison.OrdinalIgnoreCase))
            {
                List<Expense> expenses = _dataService.LoadExpenses();

                Expense? expenseToDelete = expenses.FirstOrDefault(x => x.Id == transactionId && x.UserId == userId);

                if (expenseToDelete == null)
                {
                    message = "Cheltuiala nu a fost găsită.";
                    return false;
                }

                expenses.Remove(expenseToDelete);
                _dataService.SaveExpenses(expenses);

                message = "Cheltuiala a fost ștearsă cu succes.";
                return true;
            }

            message = "Tipul tranzacției este invalid.";
            return false;
        }

        private string GetCategoryName(List<Category> categories, int categoryId)
        {
            Category? category = categories.FirstOrDefault(c => c.Id == categoryId);

            if (category == null)
                return "Necunoscută";

            return category.Name;
        }
    }
}