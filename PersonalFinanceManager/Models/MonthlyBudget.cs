namespace PersonalFinanceManager.Models
{
    public class MonthlyBudget
    {
        public int UserId { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Amount { get; set; }
    }
}