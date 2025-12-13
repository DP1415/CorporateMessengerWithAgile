using Application.Command;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Projects
{
    public class CommandDeleteProjectHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteProject, Project>(context);
}
