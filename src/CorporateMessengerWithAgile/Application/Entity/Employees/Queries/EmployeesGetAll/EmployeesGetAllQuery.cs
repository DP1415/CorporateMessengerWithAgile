using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;
using Application.Dto.Summary;

namespace Application.Entity.Employees.Queries.EmployeesGetAll
{
    public record EmployeesGetAllQuery() : AbsQueryEntityWithOptions<Employee, EmployeeSummaryDto>
        (
            [
                new Include<Employee, Company>(e => e.Company),
                new Include<Employee, PositionInCompany>(e => e.PositionInCompany),
                new Include<Employee, User>(e => e.User),
                new Include<Employee, ICollection<TeamMember>>(e => e.TeamMembers)
            ]
        );
}
