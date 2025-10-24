using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entity
{
    public class TaskItem : BaseEntity
    {
        public Project Project { get; set; } = null!;
        public Guid ProjectId { get; set; }

        public Employee Author { get; set; } = null!;
        public Guid AuthorId { get; set; }

        public Employee Responsible { get; set; } = null!;
        public Guid ResponsibleId { get; set; }

        public Sprint? SprintWithLastMention { get; set; }
        public Guid? SprintWithLastMentionId { get; set; }

        public TaskItem? ParentTask { get; set; }
        public Guid? ParentTaskId { get; set; }
        public ICollection<TaskItem> Subtasks { get; set; } = [];

        public Title Title { get; set; } = null!;
        public Text Description { get; set; } = null!;
        public int Priority { get; set; } = 1;
        public int Complexity { get; set; } = 1;
        public DateTime Deadline { get; set; }

        public ICollection<TaskItemInSprint> TaskItemInSprints { get; set; } = [];
    }
}
