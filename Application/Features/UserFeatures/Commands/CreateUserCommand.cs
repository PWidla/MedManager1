using Application.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserFeatures.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Role Role { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateUserCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                // check if user already exists
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.EmailAddress == command.EmailAddress);
                if (existingUser != null)
                {
                    throw new Exception("User with this email already exists");
                }

                var user = new User();
                user.EmailAddress = command.EmailAddress;
                user.Password = command.Password;
                user.DateOfBirth = command.DateOfBirth;
                user.Role = command.Role;

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user.Id;
            }

        }
    }
}
