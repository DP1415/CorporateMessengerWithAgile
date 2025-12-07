using Application.Query;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Users.Queries.UsersGetAll
{
    class UsersGetAllQueryHandler(AppDbContext context) : AbsQueryGetAllEntityHandler<UsersGetAllQuery, User>(context) { }
}
