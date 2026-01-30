namespace Application.Dto.Summary
{
    public class SprintSummaryDto : BaseDto
    {
        public Guid TeamId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public IReadOnlyList<Guid> TaskItemIds { get; set; } = null!;
    }
}
