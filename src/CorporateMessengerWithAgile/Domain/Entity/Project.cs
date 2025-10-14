using Domain.Common;

namespace Domain.Entity
{
    public class Project : BaseEntity
    {
        public Company Company { get; set; }
        public string Title { get; set; }
    }
}
