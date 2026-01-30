using Application.Dto.Summary;

namespace Application.Entity.Projects.Queries.GetByCompanyId
{
    public record ProjectGetByCompanyIdQueryOutput
        (
            List<ProjectSummaryDto> Projects,
            List<TaskItemSummaryDto> TaskItems,
            List<TeamSummaryDto> Teams
        );
}
