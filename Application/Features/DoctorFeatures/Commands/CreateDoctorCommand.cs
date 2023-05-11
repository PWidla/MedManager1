using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DoctorFeatures.Commands
{
    public class CreateDoctorCommand : IRequest<int>
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Role Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Specialization Specialization { get; set; }

        public class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, int>
        {
            private readonly IApplicationDbContext _context;

            public CreateDoctorCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateDoctorCommand command, CancellationToken cancellationToken)
            {
                var existingDoctor = await _context.Doctors.FirstOrDefaultAsync(d => d.EmailAddress == command.EmailAddress);
                if (existingDoctor != null)
                {
                    throw new Exception("Doctor with this email already exists");
                }

                var doctor = new Doctor();
                doctor.EmailAddress = command.EmailAddress;
                doctor.Password = command.Password;
                doctor.DateOfBirth = command.DateOfBirth;
                doctor.Role = Role.Doctor;
                doctor.FirstName = command.FirstName;
                doctor.LastName = command.LastName;
                doctor.Specialization = command.Specialization;

                _context.Doctors.Add(doctor);
                await _context.SaveChangesAsync();
                return doctor.Id;
            }
        }
    }
}
