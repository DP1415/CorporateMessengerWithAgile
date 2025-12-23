using Application.AbsCommand.Delete;
using Domain.Entity;

namespace Application.Entity.TaskItems
{
    public record CommandDeleteTaskItem(Guid Id) : AbsCommandDeleteEntityById<TaskItem>(Id);
}
