using Application.Query;
using Domain.Entity;
using MediatR;

namespace Application.Entity.Users.Queries.UsersGetAll
{
    public record UsersGetAllQuery : AbsQueryGetAllEntity<User> { }
}
