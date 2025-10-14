using Domain.Entity;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Entity.Users.Commands.UserCreate
{
    public class UserCreateCommandHandler : IRequestHandler<UserCreateCommand, Guid>
    {
        private readonly IRepository<User> _userRepository;

        public UserCreateCommandHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(UserCreateCommand request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = request.UserName
            };

            await _userRepository.AddAsync(user, cancellationToken);
            return user.Id;
        }
    }
}
