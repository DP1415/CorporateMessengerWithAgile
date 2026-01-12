using Application.AbsCommand.Delete;
using Domain.Entity;

namespace Application.Entity.TeamMembers.Commands.TeamMemberDelete
{
    public record CommandDeleteTeamMember(Guid Id) : AbsCommandDeleteEntityById<TeamMember>(Id);
}
