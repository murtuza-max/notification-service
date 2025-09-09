using FluentValidation;
using PaymentService.Model;

namespace PaymentService.Validation
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0).WithMessage("Amount must be greater than 0");
            RuleFor(x => x.Currency).NotEmpty().WithMessage("Currency is required");
            RuleFor(x => x.PayerEmail).NotEmpty().EmailAddress().WithMessage("Valid payer email is required");
            RuleFor(x => x.PaymentMethod).NotEmpty().WithMessage("Payment method is required");
        }
    }
}