using Application.Dto;
using Application.AbsQuery;
using Application.AbsQuery.Options;
using Domain.Entity;

namespace Application.Entity.Users.Queries.UsersGetAll
{
    public record UsersGetAllQuery() : AbsQueryGetAllEntity<User, UserDto>
        (
            [new Include<User, ICollection<Employee>>(user => user.Employees)]
        );
}
