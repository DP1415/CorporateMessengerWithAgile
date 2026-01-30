using Application.Dto.Summary;

namespace Application.Dto
{
    public class TeamWithRelationsDto : BaseDto
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; } = null!;
        public int StandardSprintDuration { get; set; }
        public IReadOnlyList<EmployeeSummaryDto> Users { get; set; } = [];
        public IReadOnlyList<SprintSummaryDto> Sprints { get; set; } = [];
        public IReadOnlyList<KanbanBoardColumnSummaryDto> KanbanBoardColumnIds { get; set; } = [];
    }
}
