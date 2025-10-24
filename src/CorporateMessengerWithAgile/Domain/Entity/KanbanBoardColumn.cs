using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entity
{
    public class KanbanBoardColumn : BaseEntity
    {
        public Team Team { get; set; } = null!;
        public Guid TeamId { get; set; }

        public TaskItemStatus TaskStatus { get; set; }
        public int PositionOnBoard { get; set; }
        public Title Title { get; set; } = null!;
    }
}
