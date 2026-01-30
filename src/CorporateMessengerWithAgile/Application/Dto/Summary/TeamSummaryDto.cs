namespace Application.Dto.Summary
{
    public class TeamSummaryDto : BaseDto
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; } = null!;
        public int StandardSprintDuration { get; set; }
        public IReadOnlyList<Guid> TeamMemberIds { get; set; } = null!;
        public IReadOnlyList<Guid> SprintIds { get; set; } = null!;
        public IReadOnlyList<Guid> KanbanBoardColumnIds { get; set; } = null!;
    }
}
