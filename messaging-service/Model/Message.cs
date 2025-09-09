namespace MessagingService.Model
{
    public class Message
    {
        public Guid MessageId { get; set; }
        public string Content { get; set; } = string.Empty;
        public string RecipientEmail { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDelivered { get; set; }
    }
}