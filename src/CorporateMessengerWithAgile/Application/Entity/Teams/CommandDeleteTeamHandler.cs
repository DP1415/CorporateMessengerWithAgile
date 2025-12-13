using Application.Command;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Teams
{
    public class CommandDeleteTeamHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteTeam, Team>(context);
}
