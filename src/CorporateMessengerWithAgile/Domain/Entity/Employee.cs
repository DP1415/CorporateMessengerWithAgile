using Domain.Common;

namespace Domain.Entity
{
    public class Employee : BaseEntity
    {
        public Company Company { get; set; } = null!;
        public Guid CompanyId { get; set; }

        public PositionInCompany PositionInCompany { get; set; } = null!;
        public Guid PositionInCompanyId { get; set; }

        public User User { get; set; } = null!;
        public Guid UserId { get; set; }

        public ICollection<TeamMember> TeamMembers { get; set; } = [];
    }
}
