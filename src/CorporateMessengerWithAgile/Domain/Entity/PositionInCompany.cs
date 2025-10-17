using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entity
{
    public class PositionInCompany : BaseEntity
    {
        public Company Company { get; set; } = null!;
        public Guid CompanyId { get; set; }

        public Title Title { get; set; } = null!;
        public Text Description { get; set; } = null!;

        public ICollection<Employee> Employees { get; set; } = [];
    }
}
