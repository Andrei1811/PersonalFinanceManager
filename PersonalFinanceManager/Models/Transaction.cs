namespace PersonalFinanceManager.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }

        public string Poza { get; set; } = string.Empty;
    }
}