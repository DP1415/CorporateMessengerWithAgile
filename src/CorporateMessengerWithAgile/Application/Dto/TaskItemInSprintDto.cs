using Domain.Entity;

namespace Application.Dto
{
    public class TaskItemInSprintDto : BaseDto
    {
        public Guid TaskItemId { get; set; }
        public Guid SprintId { get; set; }
        public TaskItemStatus TaskStatus { get; set; }
        public string Description { get; set; } = null!;
    }
}
