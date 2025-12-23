using Application.AbsCommand.Delete;
using Domain.Entity;

namespace Application.Entity.Sprints
{
    public record CommandDeleteSprint(Guid Id) : AbsCommandDeleteEntityById<Sprint>(Id);
}
