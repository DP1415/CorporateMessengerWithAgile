namespace Application.Dto
{
    public class TeamDto : BaseDto
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; } = null!;
        public int StandardSprintDuration { get; set; }
        public IReadOnlyList<Guid> TeamMemberIds { get; set; } = null!;
        public IReadOnlyList<Guid> SprintIds { get; set; } = null!;
        public IReadOnlyList<Guid> KanbanBoardColumnIds { get; set; } = null!;
    }
}
