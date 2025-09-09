using FluentValidation;
using PaymentService.Model;
using PaymentService.Validation;
using Microsoft.EntityFrameworkCore;

namespace PaymentService.Data
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly PostgreSqlContext _context;
        private readonly PaymentValidator _validator;

        public PaymentRepository(PostgreSqlContext context, PaymentValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public async Task<Payment?> GetPaymentByIdAsync(Guid paymentId)
        {
            return await _context.Payments.FirstOrDefaultAsync(p => p.PaymentId == paymentId);
        }

        public async Task<IResult> ProcessPaymentAsync(Payment payment)
        {
            var validationResult = await _validator.ValidateAsync(payment);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            payment.PaymentId = Guid.NewGuid();
            payment.CreatedAt = DateTime.UtcNow;
            payment.IsProcessed = true;
            payment.Status = "Completed";
            
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();
            return Results.Ok(payment);
        }

        public async Task<IResult> RefundPaymentAsync(Payment payment)
        {
            var validationResult = await _validator.ValidateAsync(payment);

            if (!validationResult.IsValid)
            {
                return Results.BadRequest(validationResult.Errors);
            }

            payment.IsRefunded = true;
            payment.Status = "Refunded";
            await _context.SaveChangesAsync();
            return Results.NoContent();
        }
    }
}