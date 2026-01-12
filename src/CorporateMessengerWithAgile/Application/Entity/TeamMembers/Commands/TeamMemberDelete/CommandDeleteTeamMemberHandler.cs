using Application.AbsCommand.Delete;
using Domain.Entity;
using Persistence;

namespace Application.Entity.TeamMembers.Commands.TeamMemberDelete
{
    public class CommandDeleteTeamMemberHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteTeamMember, TeamMember>(context);
}
