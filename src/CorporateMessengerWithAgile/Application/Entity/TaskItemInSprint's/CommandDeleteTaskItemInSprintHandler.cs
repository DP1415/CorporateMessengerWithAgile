using Application.AbsCommand.Delete;
using Domain.Entity;
using Persistence;

namespace Application.Entity.TaskItemInSprint_s
{
    public class CommandDeleteTaskItemInSprintHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteTaskItemInSprint, TaskItemInSprint>(context);
}
