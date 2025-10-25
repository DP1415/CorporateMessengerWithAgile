using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entity
{
    public class TaskItemInSprint : BaseEntity
    {
        public TaskItem TaskItem { get; set; } = null!;
        public Guid TaskItemId { get; set; }

        public Sprint Sprint { get; set; } = null!;
        public Guid SprintId { get; set; }

        public TaskItemStatus TaskStatus { get; set; }
        public Text Description { get; set; } = null!;
    }
}
