using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.PatientFeatures.Queries
{
    public class GetAllPatientsQuery : IRequest<IEnumerable<Patient>>
    {
        public class GetAllPatientsQueryHandler : IRequestHandler<GetAllPatientsQuery, IEnumerable<Patient>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllPatientsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Patient>> Handle(GetAllPatientsQuery query, CancellationToken cancellationToken)
            {
                var patientsList = await _context.Patients.ToListAsync();
                if (patientsList == null)
                {
                    return null;
                }
                return patientsList.AsReadOnly();
            }
        }
    }
}