using Application.AbsQuery;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Employees.Queries.EmployeeGetProjectsAndTeams
{
    public record EmployeeGetProjectsAndTeamsQuery
        (
            Guid EmployeeId
        )
        : AbsQueryEntity<TeamMember, EmployeeProjectsAndTeamsDto>;
}
