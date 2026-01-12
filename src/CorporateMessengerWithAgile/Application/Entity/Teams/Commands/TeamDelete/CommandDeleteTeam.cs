using Application.AbsCommand.Delete;
using Domain.Entity;

namespace Application.Entity.Teams.Commands.TeamDelete
{
    public record CommandDeleteTeam(Guid Id) : AbsCommandDeleteEntityById<Team>(Id);
}
