using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.DoctorFeatures.Commands
{
    public class DeleteDoctorByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteDoctorByIdCommandHandler : IRequestHandler<DeleteDoctorByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteDoctorByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteDoctorByIdCommand command, CancellationToken cancellationToken)
            {
                var doctor = await _context.Users.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (doctor == null) return default;
                _context.Users.Remove(doctor);
                await _context.SaveChangesAsync();
                return doctor.Id;
            }
        }
    }
}