using FluentValidation;
using MessagingService.Model;

namespace MessagingService.Validation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Message content is required");
            RuleFor(x => x.RecipientEmail).NotEmpty().EmailAddress().WithMessage("Valid recipient email is required");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject is required");
        }
    }
}