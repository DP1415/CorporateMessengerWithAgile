using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.Users.Queries.UsersGetAll
{
    class UsersGetAllQueryHandler : IRequestHandler<UsersGetAllQuery, List<User>>
    {
        private readonly AppDbContext _context;

        public UsersGetAllQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> Handle(UsersGetAllQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users
                .Include(u => u.Employees)
                .ToListAsync(cancellationToken);

            return users;
        }
    }
}
