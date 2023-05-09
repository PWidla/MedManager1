using FluentValidation;
using Domain.Entities;

namespace MedicalDataManagementApp.Infrastructure.Validators
{
    public class DoctorValidator : AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(d => d.FirstName)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(d => d.LastName)
                .NotEmpty().WithMessage("Last name is required.");

            RuleFor(d => d.Specialization)
                .NotEmpty().WithMessage("Specialization is required.");
        }
    }
}
