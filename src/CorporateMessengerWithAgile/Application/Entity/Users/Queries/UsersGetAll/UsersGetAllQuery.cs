using Application.Dto;
using Application.Query;
using Application.Query.Options;
using Domain.Entity;

namespace Application.Entity.Users.Queries.UsersGetAll
{
    public record UsersGetAllQuery() : AbsQueryWithOptions<User, UserDto>
        (
            [new Include<User, ICollection<Employee>>(user => user.Employees)]
        );
}
