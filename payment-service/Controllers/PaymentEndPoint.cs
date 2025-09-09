using MediatR;
using PaymentService.Mediatr;
using PaymentService.Model;

namespace PaymentService.Controllers
{
    public class PaymentEndPoint
    {    
        public static async Task<Payment?> GetPayment(Guid id, IMediator mediator)
        {
            return await mediator.Send(new GetPaymentByIdQuery.Query { Id = id }); 
        }

        public static async Task<IResult> RefundPayment(Guid id, IMediator mediator)
        {
            var payment = await GetPayment(id, mediator);
           
            if (payment == null)
            {
                return Results.StatusCode(StatusCodes.Status404NotFound);
            }
            return await mediator.Send(new RefundPaymentCommand.Command { Id = id });
        }

        public static async Task<IResult> ProcessPayment(ProcessPaymentCommand.Command command, IMediator mediator)
        {
            return await mediator.Send(command);
        }
    }
}