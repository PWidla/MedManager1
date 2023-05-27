using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator()
        {
            RuleFor(a => a.Nickname)
                .NotEmpty().WithMessage("Nickname address is required.")
                .MinimumLength(8).WithMessage("Nickname must be at least 3 characters long.");
        }
    }
}
