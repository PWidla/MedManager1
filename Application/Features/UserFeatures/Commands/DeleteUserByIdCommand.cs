using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductFeatures.Commands
{
    public class DeleteUserByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteUserByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
            {
                var user = await _context.Users.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (user == null) return default;
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return user.Id;
            }
        }
    }
}