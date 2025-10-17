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

        public Sprint SprintWithLastMention { get; set; } = null!;
        public Guid SprintWithLastMentionId { get; set; }

        public TaskItem? ParentTask { get; set; }
        public Guid? ParentTaskId { get; set; }

        public Title Title { get; set; }
        public Text Description { get; set; }
        public int Priority { get; set; }
        public int Complexity { get; set; }
        public DateTime Deadline { get; set; }

        public ICollection<TaskItemInSprint> TaskItemInSprints { get; set; } = [];
    }
}
