﻿using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.DoctorFeatures.Queries
{
    public class GetDoctorByIdQuery : IRequest<Doctor>
    {
        public int Id { get; set; }
        public class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, Doctor>
        {
            private readonly IApplicationDbContext _context;
            public GetDoctorByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Doctor> Handle(GetDoctorByIdQuery query, CancellationToken cancellationToken)
            {
                var doctor = _context.Doctors.Where(a => a.Id == query.Id).FirstOrDefault();
                if (doctor == null) return null;
                return doctor;
            }
        }
    }
}