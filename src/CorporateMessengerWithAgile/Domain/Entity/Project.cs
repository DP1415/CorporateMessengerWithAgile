using Domain.ValueObjects;

namespace Domain.Entity
{
    public class Project : BaseEntity
    {
        public Company Company { get; set; } = null!;
        public Guid CompanyId { get; set; }

        public Title Title { get; set; } = null!;

        public ICollection<TaskItem> TaskItems { get; set; } = [];
        public ICollection<Team> Teams { get; set; } = [];
    }
}
