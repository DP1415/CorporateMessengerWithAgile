using Domain.Common;

namespace Domain.Entity
{
    public class Team : BaseEntity
    {
        public Project Project { get; set; }
        public string Title { get; set; }
        public int StandardSprintDuration { get; set; }
    }
}
