using Application.Command;
using Domain.Entity;
using Persistence;

namespace Application.Entity.TaskItems
{
    public class CommandDeleteTaskItemHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteTaskItem, TaskItem>(context);
}
