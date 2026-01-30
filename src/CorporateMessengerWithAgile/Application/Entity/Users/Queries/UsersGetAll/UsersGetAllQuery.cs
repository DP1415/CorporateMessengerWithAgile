using Application.AbsQuery;
using Application.AbsQuery.Options;
using Domain.Entity;
using Application.Dto.Summary;

namespace Application.Entity.Users.Queries.UsersGetAll
{
    public record UsersGetAllQuery() : AbsQueryEntityWithOptions<User, UserSummaryDto>
        (
            [new Include<User, ICollection<Employee>>(user => user.Employees)]
        );
}
