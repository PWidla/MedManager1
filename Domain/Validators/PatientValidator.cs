using Domain.Entities;
using FluentValidation;
using MedicalDataManagementApp.Core.Entities;

namespace Domain.Validators
{
    public class PatientValidator : AbstractValidator<Patient>
    {
        public PatientValidator()
        {
            RuleFor(p => p.FirstName)
                .NotEmpty().WithMessage("First name is required.");

            RuleFor(p => p.LastName)
                .NotEmpty().WithMessage("Last name is required.");
        }
    }
}