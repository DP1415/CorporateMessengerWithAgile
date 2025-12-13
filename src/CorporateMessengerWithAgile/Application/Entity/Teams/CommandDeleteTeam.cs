using Application.Command;
using Domain.Entity;

namespace Application.Entity.Teams
{
    public record CommandDeleteTeam(Guid Id) : AbsCommandDeleteEntityById<Team>(Id);
}
