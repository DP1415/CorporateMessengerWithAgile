namespace Application.Dto
{
    public class TeamDetailsDto : BaseDto
    {
        public Guid ProjectId { get; set; }
        public string Title { get; set; } = null!;
        public int StandardSprintDuration { get; set; }
        public IReadOnlyList<EmployeeDto> Users { get; set; } = [];
        public IReadOnlyList<SprintDto> Sprints { get; set; } = [];
        public IReadOnlyList<KanbanBoardColumnDto> KanbanBoardColumnIds { get; set; } = [];
    }
}
