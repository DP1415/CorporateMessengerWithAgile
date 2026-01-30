namespace Application.Dto.Summary
{
    public class ProjectSummaryDto : BaseDto
    {
        public Guid CompanyId { get; set; }
        public string Title { get; set; } = null!;
        public IReadOnlyList<Guid> TaskItemIds { get; set; } = null!;
        public IReadOnlyList<Guid> TeamIds { get; set; } = null!;
    }
}
