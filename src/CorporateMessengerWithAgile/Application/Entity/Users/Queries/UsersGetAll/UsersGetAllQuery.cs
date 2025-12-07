using Application.Abstractions.Query;
using Domain.Entity;
using MediatR;

namespace Application.Entity.Users.Queries.UsersGetAll
{
    public record UsersGetAllQuery : AbsEntityGetAllQuery<User> { }
}
