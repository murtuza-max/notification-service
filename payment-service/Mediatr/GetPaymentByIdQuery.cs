using MediatR;
using PaymentService.Data;
using PaymentService.Model;

namespace PaymentService.Mediatr
{
    public class GetPaymentByIdQuery
    {
        public class Query : IRequest<Payment?>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Payment?>
        {
            private readonly IPaymentRepository _paymentRepository;

            public Handler(IPaymentRepository paymentRepository)
            {
                _paymentRepository = paymentRepository;
            }

            public async Task<Payment?> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _paymentRepository.GetPaymentByIdAsync(request.Id);
            }
        }
    }
}