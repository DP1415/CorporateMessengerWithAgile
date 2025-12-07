using Application.Abstractions.Query;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Users.Queries.UsersGetAll
{
    class UsersGetAllQueryHandler(AppDbContext context) : AbsEntityGetAllQueryHandler<UsersGetAllQuery, User>(context) { }
}
