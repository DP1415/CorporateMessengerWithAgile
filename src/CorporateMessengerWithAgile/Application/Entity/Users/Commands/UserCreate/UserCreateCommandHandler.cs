using Domain.Entity;
using Domain.ValueObjects;
using MediatR;
using Persistence;

namespace Application.Entity.Users.Commands.UserCreate
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, Guid>
    {
        private readonly AppDbContext _context;

        public UserCreateCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Username = Username.Create(request.UserName),
                Email = Email.Create(request.Email),
                PasswordHashed = PasswordHashed.Create(request.password)
            };

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return user.Id;
        }
    }
}
