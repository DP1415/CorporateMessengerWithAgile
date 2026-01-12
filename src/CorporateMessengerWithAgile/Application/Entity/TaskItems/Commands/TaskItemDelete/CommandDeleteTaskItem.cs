using Application.AbsCommand.Delete;
using Domain.Entity;

namespace Application.Entity.TaskItems.Commands.TaskItemDelete
{
    public record CommandDeleteTaskItem(Guid Id) : AbsCommandDeleteEntityById<TaskItem>(Id);
}
