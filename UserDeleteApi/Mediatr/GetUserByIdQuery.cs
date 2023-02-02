using DeleteUser.Data;
using DeleteUser.Model;



namespace DeleteUser.Mediatr
{
    public class GetUserByIdQuery
    {
        public class Query : IRequest<User>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, User>
        {
            private readonly IUserRepository _repository;

            public Handler(IUserRepository repository)
            {
                _repository = repository;
            }

            public Task<User> Handle(Query request, CancellationToken cancellationToken)
            {
                return _repository.GetUserByIdAsync(request.Id);
            }
        }
    }
}
