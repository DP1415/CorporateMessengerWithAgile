using Application.Dto;

namespace Application.Entity.Projects.Queries.GetByCompanyId
{
    public record ProjectGetByCompanyIdDto
        (
            List<ProjectDto> Projects,
            List<TaskItemDto> TaskItems,
            List<TeamDto> Teams
        );
}
