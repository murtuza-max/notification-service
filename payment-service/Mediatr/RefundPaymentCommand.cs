using MediatR;
using PaymentService.Data;

namespace PaymentService.Mediatr
{
    public class RefundPaymentCommand
    {
        public class Command : IRequest<IResult>
        {
            public Guid Id { get; set; }
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
                var payment = await _paymentRepository.GetPaymentByIdAsync(request.Id);
                
                if (payment == null)
                {
                    return Results.NotFound();
                }

                return await _paymentRepository.RefundPaymentAsync(payment);
            }
        }
    }
}