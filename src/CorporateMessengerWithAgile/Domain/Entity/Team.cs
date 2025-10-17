using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entity
{
    public class Team : BaseEntity
    {
        public Project Project { get; set; } = null!;
        public Guid ProjectId { get; set; }

        public Title Title { get; set; } = null!;
        public int StandardSprintDuration { get; set; }

        public ICollection<TeamMember> TeamMembers { get; set; } = [];
        public ICollection<Sprint> Sprints { get; set; } = [];
        public ICollection<KanbanBoardColumn> KanbanBoardColumns { get; set; } = [];
    }
}
