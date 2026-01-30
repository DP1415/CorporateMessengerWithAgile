using Domain.Entity;

namespace Application.Dto.Summary
{
    public class KanbanBoardColumnSummaryDto : BaseDto
    {
        public Guid TeamId { get; set; }
        public TaskItemStatus TaskStatus { get; set; }
        public int PositionOnBoard { get; set; }
        public string Title { get; set; } = null!;
    }
}
