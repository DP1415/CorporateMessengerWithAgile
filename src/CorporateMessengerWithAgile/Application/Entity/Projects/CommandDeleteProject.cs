using Application.AbsCommand.Delete;
using Domain.Entity;

namespace Application.Entity.Projects
{
    public record CommandDeleteProject(Guid Id) : AbsCommandDeleteEntityById<Project>(Id);
}
