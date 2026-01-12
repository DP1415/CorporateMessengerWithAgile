using Application.AbsCommand.Delete;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Sprints.Commands.SprintDelete
{
    public class CommandDeleteSprintHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteSprint, Sprint>(context);
}
