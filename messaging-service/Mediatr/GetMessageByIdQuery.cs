using MediatR;
using MessagingService.Data;
using MessagingService.Model;

namespace MessagingService.Mediatr
{
    public class GetMessageByIdQuery
    {
        public class Query : IRequest<Message?>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Message?>
        {
            private readonly IMessageRepository _messageRepository;

            public Handler(IMessageRepository messageRepository)
            {
                _messageRepository = messageRepository;
            }

            public async Task<Message?> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _messageRepository.GetMessageByIdAsync(request.Id);
            }
        }
    }
}