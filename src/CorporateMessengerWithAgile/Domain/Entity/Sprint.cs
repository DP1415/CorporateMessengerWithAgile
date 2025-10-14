using Domain.Common;

namespace Domain.Entity
{
    public class Sprint : BaseEntity
    {
        public Team Team { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
