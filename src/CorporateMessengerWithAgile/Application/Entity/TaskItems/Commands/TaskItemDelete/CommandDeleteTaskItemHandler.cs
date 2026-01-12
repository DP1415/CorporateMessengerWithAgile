using Application.AbsCommand.Delete;
using Domain.Entity;
using Persistence;

namespace Application.Entity.TaskItems.Commands.TaskItemDelete
{
    public class CommandDeleteTaskItemHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteTaskItem, TaskItem>(context);
}
