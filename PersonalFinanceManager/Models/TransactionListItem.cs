namespace PersonalFinanceManager.Models
{
    public class TransactionListItem
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Date { get; set; } = string.Empty;

        public string Poza { get; set; } = string.Empty;
    }
}