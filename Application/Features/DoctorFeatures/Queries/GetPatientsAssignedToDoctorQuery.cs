using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.DoctorFeatures.Queries
{
    public class GetPatientsAssignedToDoctorQuery : IRequest<IEnumerable<Patient>>
    {
        public Doctor doctor { get; set; }

        public class GetPatientsAssignedToDoctorQueryHandler : IRequestHandler<GetPatientsAssignedToDoctorQuery, IEnumerable<Patient>>
        {
            private readonly IApplicationDbContext _context;
            public GetPatientsAssignedToDoctorQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Patient>> Handle(GetDoctorsBySpecializationQuery query, CancellationToken cancellationToken)
            {
                var patients = await _context.Patients
                    .Where(d => d.Specialization == specialization)
                    .ToListAsync(cancellationToken);

                return doctors;
            }
        }
    }
}
