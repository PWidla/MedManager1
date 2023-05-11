using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Domain.Enums; 

namespace Application.Features.DoctorFeatures.Queries
{
    public class GetDoctorsBySpecializationQuery : IRequest<IEnumerable<Doctor>>
    {
        public string Specialization { get; set; }

        public class GetDoctorsBySpecializationQueryHandler : IRequestHandler<GetDoctorsBySpecializationQuery, IEnumerable<Doctor>>
        {
            private readonly IApplicationDbContext _context;
            public GetDoctorsBySpecializationQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Doctor>> Handle(GetDoctorsBySpecializationQuery query, CancellationToken cancellationToken)
            {
                var specialization = (Specialization)Enum.Parse(typeof(Specialization), query.Specialization, true);

                var doctors = await _context.Doctors
                    .Include(d => d.Specialization)
                    .Where(d => d.Specialization == specialization)
                    .ToListAsync(cancellationToken);

                return doctors;
            }
        }
    }
}
