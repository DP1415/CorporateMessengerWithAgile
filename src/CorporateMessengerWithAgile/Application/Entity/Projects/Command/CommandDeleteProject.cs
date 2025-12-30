using Application.AbsCommand.Delete;
using Domain.Entity;

namespace Application.Entity.Projects.Command
{
    public record CommandDeleteProject(Guid Id) : AbsCommandDeleteEntityById<Project>(Id);
}
