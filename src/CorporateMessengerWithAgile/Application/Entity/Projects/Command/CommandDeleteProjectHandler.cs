using Application.AbsCommand.Delete;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Projects.Command
{
    public class CommandDeleteProjectHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteProject, Project>(context);
}
