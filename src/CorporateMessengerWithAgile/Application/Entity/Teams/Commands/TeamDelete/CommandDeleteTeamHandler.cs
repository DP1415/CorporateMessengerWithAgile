using Application.AbsCommand.Delete;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Teams.Commands.TeamDelete
{
    public class CommandDeleteTeamHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteTeam, Team>(context);
}
