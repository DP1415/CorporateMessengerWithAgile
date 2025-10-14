using Domain.Common;

namespace Domain.Entity
{
    public class TeamMember : BaseEntity
    {
        public Employee Employee { get; set; }
        public Team Team { get; set; }
    }
}
