using Application.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.PatientFeatures.Queries
{
    public class GetPatientByIdQuery : IRequest<Patient>
    {
        public int Id { get; set; }
        public class GetPatientByIdQueryHandler : IRequestHandler<GetPatientByIdQuery, Patient>
        {
            private readonly IApplicationDbContext _context;
            public GetPatientByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Patient> Handle(GetPatientByIdQuery query, CancellationToken cancellationToken)
            {
                var patient = await _context.Patients.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                if (patient == null) return null;
                return patient;
            }
        }
    }
}