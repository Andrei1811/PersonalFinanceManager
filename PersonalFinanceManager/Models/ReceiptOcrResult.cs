namespace PersonalFinanceManager.Models
{
    public class ReceiptOcrResult
    {
        public DateTime? Date { get; set; }
        public decimal? Total { get; set; }
        public string RawText { get; set; } = string.Empty;
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }
}