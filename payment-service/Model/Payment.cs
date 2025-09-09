namespace PaymentService.Model
{
    public class Payment
    {
        public Guid PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public string PayerEmail { get; set; } = string.Empty;
        public string PaymentMethod { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsProcessed { get; set; }
        public bool IsRefunded { get; set; }
        public string Status { get; set; } = "Pending";
    }
}