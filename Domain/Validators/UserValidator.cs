using Domain.Entities;
using FluentValidation;

namespace Domain.Validators
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

            RuleFor(u => u.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .Must(dob => dob < DateTime.UtcNow.AddYears(-18)).WithMessage("You must be at least 18 years old.");

            RuleFor(u => u.Role)
                .NotNull().WithMessage("Role is required.")
                .IsInEnum().WithMessage("Invalid role.");
        }
    }
}
