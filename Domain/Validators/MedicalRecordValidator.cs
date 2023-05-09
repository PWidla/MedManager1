using FluentValidation;
using Domain.Entities;

namespace Domain.Validators
{
    public class MedicalRecordValidator : AbstractValidator<MedicalRecord>
    {
        public MedicalRecordValidator()
        {
            RuleFor(x => x.MedicalHistory)
                .NotEmpty().WithMessage("Medical history cannot be empty.")
                .MaximumLength(5000).WithMessage("Medical history must be less than 5000 characters long.");

            RuleFor(x => x.PatientId)
                .NotEmpty().WithMessage("Patient ID cannot be empty.");

            RuleFor(x => x.DoctorId)
                .NotEmpty().WithMessage("Doctor ID cannot be empty.");
        }
    }
}
