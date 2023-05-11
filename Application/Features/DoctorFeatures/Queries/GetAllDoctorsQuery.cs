using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.DoctorFeatures.Queries
{
    public class GetAllDoctorsQuery : IRequest<IEnumerable<Doctor>>
    {
        public class GetAllDoctorsQueryHandler : IRequestHandler<GetAllDoctorsQuery, IEnumerable<Doctor>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllDoctorsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Doctor>> Handle(GetAllDoctorsQuery query, CancellationToken cancellationToken)
            {
                var doctorList = await _context.Doctors.ToListAsync();
                if (doctorList == null)
                {
                    return null;
                }
                return doctorList.AsReadOnly();
            }
        }
    }
}