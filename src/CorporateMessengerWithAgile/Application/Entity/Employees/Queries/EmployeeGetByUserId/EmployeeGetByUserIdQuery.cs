using Application.AbsQuery;
using Application.Dto.Summary;
using Domain.Entity;

namespace Application.Entity.Employees.Queries.EmployeeGetByUserId
{
    public record ProjectWithTeams
        (
            ProjectSummaryDto Project,
            IEnumerable<TeamSummaryDto> Teams
        );

    public record EmployeeWithRelations
        (
            Guid EmployeeId,
            CompanySummaryDto Company,
            PositionInCompanySummaryDto PositionInCompany,
            IEnumerable<ProjectWithTeams> ProjectsAndTeams
        );

    public record EmployeeGetByUserIdQuery
        (
            Guid UserId
        )
        : AbsQueryEntity<TeamMember, IEnumerable<EmployeeWithRelations>>
    {
    }
}
