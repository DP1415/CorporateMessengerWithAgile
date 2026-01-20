using Application.AbsQuery;
using Application.AbsQuery.Options;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Employees.Queries.EmployeeGetByUserId
{
    public record EmployeeGetByUserIdQuery(Guid UserId)
        : AbsQueryEntityWithOptions<Employee, WorkplaceDto>(
            [
                new Filter<Employee>(e => e.UserId == UserId),
                new Include<Employee, Company>(e => e.Company),
                new Include<Employee, PositionInCompany>(e => e.PositionInCompany),
                new Include<Employee, User>(e => e.User),
                new Include<Employee, ICollection<TeamMember>>(e => e.TeamMembers)
            ]
        );
}
