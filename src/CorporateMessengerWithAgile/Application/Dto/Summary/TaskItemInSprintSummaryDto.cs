using Domain.Entity;

namespace Application.Dto.Summary
{
    public class TaskItemInSprintSummaryDto : BaseDto
    {
        public Guid TaskItemId { get; set; }
        public Guid SprintId { get; set; }
        public TaskItemStatus TaskStatus { get; set; }
    }
}
