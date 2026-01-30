using Application.Dto.Summary;

namespace Application.Entity.Employees.Queries.EmployeeGetProjectsAndTeams
{
    public record ProjectWithTeams
        (
            ProjectSummaryDto Project,
            IReadOnlyCollection<TeamSummaryDto> Teams
        );
}
