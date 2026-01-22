using Application.Dto;

namespace Application.Entity.Employees.Queries.EmployeeGetProjectsAndTeams
{
    public record ProjectWithTeams
        (
            ProjectDto Project,
            IReadOnlyCollection<TeamDto> Teams
        );
}
