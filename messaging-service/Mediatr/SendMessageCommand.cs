using MediatR;
using MessagingService.Data;
using MessagingService.Model;

namespace MessagingService.Mediatr
{
    public class SendMessageCommand
    {
        public class Command : IRequest<IResult>
        {
            public string Content { get; set; } = string.Empty;
            public string RecipientEmail { get; set; } = string.Empty;
            public string Subject { get; set; } = string.Empty;
        }

        public class Handler : IRequestHandler<Command, IResult>
        {
            private readonly IMessageRepository _messageRepository;

            public Handler(IMessageRepository messageRepository)
            {
                _messageRepository = messageRepository;
            }

            public async Task<IResult> Handle(Command request, CancellationToken cancellationToken)
            {
                var message = new Message
                {
                    Content = request.Content,
                    RecipientEmail = request.RecipientEmail,
                    Subject = request.Subject,
                    IsDeleted = false,
                    IsDelivered = false
                };

                return await _messageRepository.SendMessageAsync(message);
            }
        }
    }
}