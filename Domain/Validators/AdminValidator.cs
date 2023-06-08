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

            RuleFor(u => u.EmailAddress)
                 .NotEmpty().WithMessage("Email address is required.")
                 .EmailAddress().WithMessage("Invalid email address.");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

            RuleFor(u => u.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required.")
                .Must(dob => dob < DateTime.UtcNow.AddYears(-18)).WithMessage("You must be at least 18 years old.");
        }
    }
}
