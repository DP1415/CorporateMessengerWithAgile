using Application.AbsQuery;
using Domain.Entity;

namespace Application.Entity.Employees.Queries.EmployeeGetProjectsAndTeams
{
    public record EmployeeGetProjectsAndTeamsQuery
        (
            Guid EmployeeId
        )
        : AbsQueryEntity<TeamMember, ProjectWithTeams[]>;
}
