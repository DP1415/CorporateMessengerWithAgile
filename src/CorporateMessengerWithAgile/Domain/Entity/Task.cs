using Domain.Common;

namespace Domain.Entity
{
    public class Task : BaseEntity
    {
        public Project Project { get; set; }
        public Employee Author { get; set; }
        public Sprint SprintWithLastMention { get; set; }
        public Task? ParentTask { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int Complexity { get; set; }
        public DateTime Deadline { get; set; }
    }
}
