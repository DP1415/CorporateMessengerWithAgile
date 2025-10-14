using Domain.Common;

namespace Domain.Entity
{
    public class KanbanBoardColumn : BaseEntity
    {
        public Team Team { get; set; }
        public TaskStatus TaskStatus { get; set; }
        public int PositionOnBoard { get; set; }
        public string Title { get; set; }
    }
}
