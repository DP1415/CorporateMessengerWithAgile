using Application.Command;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Sprints
{
    public class CommandDeleteSprintHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteSprint, Sprint>(context);
}
