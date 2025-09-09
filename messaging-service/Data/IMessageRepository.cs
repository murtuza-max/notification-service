using MessagingService.Model;

namespace MessagingService.Data
{
    public interface IMessageRepository
    {
        Task<Message?> GetMessageByIdAsync(Guid messageId);
        Task<IResult> DeleteMessageAsync(Message message);
        Task<IResult> SendMessageAsync(Message message);
    }
}