using Application.AbsCommand.Delete;
using Domain.Entity;
using Persistence;

namespace Application.Entity.TaskItemInSprints.Commands.TaskItemInSprintDelete
{
    public class CommandDeleteTaskItemInSprintHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteTaskItemInSprint, TaskItemInSprint>(context);
}
