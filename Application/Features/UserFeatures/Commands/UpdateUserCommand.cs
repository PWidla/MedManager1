using Application.Interfaces;
using Domain.Enums;
using MediatR;

namespace Application.Features.UserFeatures.Commands
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Role Role { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateUserCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                var user = _context.Users.Where(a => a.Id == command.Id).FirstOrDefault();

                if (user == null)
                {
                    return default;
                }
                else
                {
                    user.EmailAddress = command.EmailAddress;
                    user.Password = command.Password;
                    user.DateOfBirth = command.DateOfBirth;
                    user.Role = command.Role;

                    await _context.SaveChangesAsync();
                    return user.Id;
                }
            }
        }
    }
}
