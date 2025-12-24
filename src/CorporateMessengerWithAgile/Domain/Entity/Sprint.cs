namespace Domain.Entity
{
    public class Sprint : BaseEntity
    {
        public Team Team { get; set; } = null!;
        public Guid TeamId { get; set; }

        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }

        public ICollection<TaskItem> TaskItems { get; set; } = [];
        public ICollection<TaskItemInSprint> TaskItemInSprints { get; set; } = [];
    }
}
