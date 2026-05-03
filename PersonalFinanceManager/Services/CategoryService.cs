using PersonalFinanceManager.Data;
using PersonalFinanceManager.Models;

namespace PersonalFinanceManager.Services
{
    public class CategoryService
    {
        private readonly JsonDataService _dataService;

        public CategoryService()
        {
            _dataService = new JsonDataService();
        }

        public List<Category> GetCategories()
        {
            return _dataService.LoadCategories();
        }

        public bool AddCategory(string name, string type, out string message)
        {
            name = name.Trim();
            type = type.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                message = "Numele categoriei este obligatoriu.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(type))
            {
                message = "Tipul categoriei este obligatoriu.";
                return false;
            }

            if (type != "Income" && type != "Expense")
            {
                message = "Tipul categoriei este invalid.";
                return false;
            }

            List<Category> categories = _dataService.LoadCategories();

            bool categoryExists = categories.Any(c =>
                c.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                c.Type.Equals(type, StringComparison.OrdinalIgnoreCase));

            if (categoryExists)
            {
                message = "Există deja o categorie cu acest nume pentru tipul selectat.";
                return false;
            }

            int newId = categories.Count > 0 ? categories.Max(c => c.Id) + 1 : 1;

            Category newCategory = new Category
            {
                Id = newId,
                Name = name,
                Type = type
            };

            categories.Add(newCategory);
            _dataService.SaveCategories(categories);

            message = "Categoria a fost adăugată cu succes.";
            return true;
        }
    }
}