using Application.AbsCommand.Delete;
using Domain.Entity;

namespace Application.Entity.Sprints.Commands.SprintDelete
{
    public record CommandDeleteSprint(Guid Id) : AbsCommandDeleteEntityById<Sprint>(Id);
}
