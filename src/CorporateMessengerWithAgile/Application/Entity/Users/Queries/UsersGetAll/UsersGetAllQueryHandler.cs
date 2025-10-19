using Domain.Entity;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Entity.Users.Queries.UsersGetAll
{
    class UsersGetAllQueryHandler : IRequestHandler<UsersGetAllQuery, List<UserDto>>
    {
        private readonly IRepository<User> _userRepository;

        public UsersGetAllQueryHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserDto>> Handle(UsersGetAllQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync(cancellationToken);

            return users.Select(user => new UserDto(
                Email: user.Email.Value,
                Username: user.Username.Value,
                PasswordHashed: user.PasswordHashed.Value,
                Employees: user.Employees,
                Id: user.Id,
                CreatedAt: user.CreatedAt,
                UpdatedAt: user.UpdatedAt
            )).ToList();
            //var users = await _userRepository.GetAllAsync(cancellationToken);
            //return users;
        }
    }
}
