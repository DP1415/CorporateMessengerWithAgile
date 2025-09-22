using Domain.Entity;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Entity.Users.Queries.UsersGetAll
{
    class UsersGetAllQueryHandler : IRequestHandler<UsersGetAllQuery, List<User>>
    {
        private readonly IRepository<User> _userRepository;

        public UsersGetAllQueryHandler(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> Handle(UsersGetAllQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync(cancellationToken);
            return users;
        }
    }
}
