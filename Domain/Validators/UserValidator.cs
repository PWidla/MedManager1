using FluentValidation;
using MedicalDataManagementApp.Core.Entities;

namespace MedicalDataManagementApp.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.EmailAddress)
                 .NotEmpty().WithMessage("Email address is required.")
                 .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

            RuleFor(u => u.Role)
                .NotNull().WithMessage("Role is required.")
                .IsInEnum().WithMessage("Invalid role.");
        }
    }
}
