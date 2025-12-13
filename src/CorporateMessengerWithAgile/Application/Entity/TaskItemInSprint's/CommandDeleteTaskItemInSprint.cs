using Application.Command;
using Domain.Entity;

namespace Application.Entity.TaskItemInSprint_s
{
    public record CommandDeleteTaskItemInSprint(Guid Id) : AbsCommandDeleteEntityById<TaskItemInSprint>(Id);
}
