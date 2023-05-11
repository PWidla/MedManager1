using Application.Interfaces;
using Domain.Enums;
using MediatR;

namespace Application.Features.DoctorFeatures.Commands
{
    public class UpdateDoctorCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Role Role { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Specialization Specialization { get; set; }


        public class UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateDoctorCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateDoctorCommand command, CancellationToken cancellationToken)
            {
                var doctor = _context.Doctors.FirstOrDefault(d => d.Id == command.Id);

                if (doctor == null)
                {
                    return default;
                }
                else
                {
                    doctor.EmailAddress = command.EmailAddress;
                    doctor.Password = command.Password;
                    doctor.DateOfBirth = command.DateOfBirth;
                    doctor.Role = command.Role;
                    doctor.FirstName = command.FirstName;
                    doctor.LastName = command.LastName;
                    doctor.Specialization = command.Specialization;

                    await _context.SaveChangesAsync();
                    return doctor.Id;
                }
            }
        }

    }
}
