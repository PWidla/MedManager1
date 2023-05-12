using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.PatientFeatures.Commands
{
    public class CreatePatientCommand : IRequest<int>
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Role Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MedicalHistory { get; set; }


        public class CreatePatientCommandHandler : IRequestHandler<CreatePatientCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreatePatientCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreatePatientCommand command, CancellationToken cancellationToken)
            {
                var existingPatient = await _context.Patients.FirstOrDefaultAsync(d => d.EmailAddress == command.EmailAddress);
                if (existingPatient != null)
                {
                    throw new Exception("Doctor with this email already exists");
                }

                var patient = new Patient();
                patient.EmailAddress = command.EmailAddress;
                patient.Password = command.Password;
                patient.DateOfBirth = command.DateOfBirth;
                patient.Role = Role.Patient;
                patient.FirstName = command.FirstName;
                patient.LastName = command.LastName;
                patient.MedicalHistory = command.MedicalHistory;

                _context.Patients.Add(patient);
                await _context.SaveChangesAsync();
                return patient.Id;
            }
        }
    }
}
