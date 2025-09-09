using MediatR;
using PaymentService.Data;
using PaymentService.Model;

namespace PaymentService.Mediatr
{
    public class ProcessPaymentCommand
    {
        public class Command : IRequest<IResult>
        {
            public decimal Amount { get; set; }
            public string Currency { get; set; } = string.Empty;
            public string PayerEmail { get; set; } = string.Empty;
            public string PaymentMethod { get; set; } = string.Empty;
        }

        public class Handler : IRequestHandler<Command, IResult>
        {
            private readonly IPaymentRepository _paymentRepository;

            public Handler(IPaymentRepository paymentRepository)
            {
                _paymentRepository = paymentRepository;
            }

            public async Task<IResult> Handle(Command request, CancellationToken cancellationToken)
            {
                var payment = new Payment
                {
                    Amount = request.Amount,
                    Currency = request.Currency,
                    PayerEmail = request.PayerEmail,
                    PaymentMethod = request.PaymentMethod,
                    IsProcessed = false,
                    IsRefunded = false,
                    Status = "Pending"
                };

                return await _paymentRepository.ProcessPaymentAsync(payment);
            }
        }
    }
}