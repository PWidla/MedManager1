using FluentValidation;
using Domain.Entities;

namespace Domain.Validators
{
    public class DoctorValidator : AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(d => d.FirstName)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(d => d.LastName)
                .NotEmpty().WithMessage("Last name is required.");

            RuleFor(u => u.Role)
                .NotNull().WithMessage("Role is required.")
                .IsInEnum().WithMessage("Invalid role.");

            RuleFor(d => d.Specialization)
                .NotNull().WithMessage("Specialization is required.")
                .IsInEnum().WithMessage("Invalid role.");
        }
    }
}
