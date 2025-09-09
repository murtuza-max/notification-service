using MediatR;
using MessagingService.Data;

namespace MessagingService.Mediatr
{
    public class DeleteMessageByIdCommand
    {
        public class Command : IRequest<IResult>
        {
            public Guid Id { get; set; }
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
                var message = await _messageRepository.GetMessageByIdAsync(request.Id);
                
                if (message == null)
                {
                    return Results.NotFound();
                }

                return await _messageRepository.DeleteMessageAsync(message);
            }
        }
    }
}