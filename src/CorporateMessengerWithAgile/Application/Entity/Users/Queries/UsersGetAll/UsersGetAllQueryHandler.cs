using Domain.Abstract.DBQueryDesigner;
using Domain.Entity;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Entity.Users.Queries.UsersGetAll
{
    class UsersGetAllQueryHandler : IRequestHandler<UsersGetAllQuery, List<UserDto>>
    {
        private readonly IRepository<User> _userRepository;
        private readonly IDBQueryDesignerSet<User> _dBQueryDesignerSet;

        public UsersGetAllQueryHandler(IRepository<User> userRepository, IDBQueryDesignerSet<User> dBQueryDesignerSet)
        {
            _userRepository = userRepository;
            _dBQueryDesignerSet = dBQueryDesignerSet;
        }

        public async Task<List<UserDto>> Handle(UsersGetAllQuery request, CancellationToken cancellationToken)
        {
            User[] arr = await _dBQueryDesignerSet.SendAsync(cancellationToken);
            List<User> list = new(arr);


            //var users = await _userRepository.GetAllAsync(cancellationToken);

            return [.. arr.Select(user => new UserDto(
                Email: user.Email.Value,
                Username: user.Username.Value,
                PasswordHashed: user.PasswordHashed.Value,
                Employees: user.Employees,
                Id: user.Id,
                CreatedAt: user.CreatedAt,
                UpdatedAt: user.UpdatedAt
            ))];
            //var users = await _userRepository.GetAllAsync(cancellationToken);
            //return users;
        }
    }
}
