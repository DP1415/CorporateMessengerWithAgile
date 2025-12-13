using Application.Command;
using Domain.Entity;

namespace Application.Entity.TeamMembers
{
    public record CommandDeleteTeamMember(Guid Id) : AbsCommandDeleteEntityById<TeamMember>(Id);
}
