using PaymentService.Model;

namespace PaymentService.Data
{
    public interface IPaymentRepository
    {
        Task<Payment?> GetPaymentByIdAsync(Guid paymentId);
        Task<IResult> ProcessPaymentAsync(Payment payment);
        Task<IResult> RefundPaymentAsync(Payment payment);
    }
}