using FluentValidation;
using MessagingService.Model;
using MessagingService.Validation;
using Microsoft.EntityFrameworkCore;

namespace MessagingService.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly PostgreSqlContext _context;
        private readonly MessageValidator _validator;

        public MessageRepository(PostgreSqlContext context, MessageValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<Message?> GetMessageByIdAsync(Guid messageId)
        {
            return await _context.Messages.FirstOrDefaultAsync(m => m.MessageId == messageId);
        }

        public async Task<IResult> DeleteMessageAsync(Message message)
        {
            var validationResult = await _validator.ValidateAsync(message);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            message.IsDeleted = true;
            await _context.SaveChangesAsync();
            return Results.NoContent();
        }

        public async Task<IResult> SendMessageAsync(Message message)
        {
            var validationResult = await _validator.ValidateAsync(message);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            message.MessageId = Guid.NewGuid();
            message.CreatedAt = DateTime.UtcNow;
            message.IsDelivered = true;
            
            _context.Messages.Add(message);
            await _context.SaveChangesAsync();
            return Results.Ok(message);
        }
    }
}