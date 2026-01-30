namespace Application.Dto.Summary
{
    public class TaskItemSummaryDto : BaseDto
    {
        public Guid ProjectId { get; set; }
        public Guid AuthorId { get; set; }
        public Guid ResponsibleId { get; set; }
        public Guid? SprintWithLastMentionId { get; set; }
        public Guid? ParentTaskId { get; set; }
        public IReadOnlyList<Guid> SubtaskIds { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Priority { get; set; }
        public int Complexity { get; set; }
        public DateTime Deadline { get; set; }
    }
}
