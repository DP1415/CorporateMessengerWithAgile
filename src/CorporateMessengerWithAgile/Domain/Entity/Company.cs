using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entity
{
    public class Company : BaseEntity
    {
        public Title Title { get; set; } = null!;

        public ICollection<Employee> Employees { get; set; } = [];
        public ICollection<PositionInCompany> Positions { get; set; } = [];
        public ICollection<Project> Projects { get; set; } = [];
    }
}
