
using DeleteUser.Model;

namespace DeleteUser.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").
                Must(IsValidName);
            RuleFor(x => x.IsDeleted).Equal(false).WithMessage("User Account Already Deleted!");
        }
        public bool IsValidName(string name)
        {
            return name.All(Char.IsLetter);
        }
    }
}
