using Domain.Common;

namespace Domain.Entity
{
    public class TeamMember : BaseEntity
    {
        public Employee Employee { get; set; } = null!;
        public Guid EmployeeId { get; set; }

        public Team Team { get; set; } = null!;
        public Guid TeamId { get; set; }
    }
}
