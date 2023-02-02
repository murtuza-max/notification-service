using DeleteUser.Data;
using DeleteUser.Model;
using DeleteUser.Validation;

namespace DeleteUser.Mediatr
{
    public class DeleteUserbyIdCommand
    {
        public class Command : IRequest<IResult>
        {
            public Guid Id { get; set; }
        }
        public class CommandHandler : IRequestHandler<Command, IResult>
        {
            private readonly IUserRepository _repository;

            public CommandHandler(IUserRepository repository)
            {
                _repository = repository;
            }
            public Task<IResult> Handle(Command request, CancellationToken cancellationToken)
            {
                return _repository.DeleteUserByIdAsync(request.Id);
            }
        }
    }
}
