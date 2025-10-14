using Domain.Common;

namespace Domain.Entity
{
    public class PositionInCompany : BaseEntity
    {
        public Company Company { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
