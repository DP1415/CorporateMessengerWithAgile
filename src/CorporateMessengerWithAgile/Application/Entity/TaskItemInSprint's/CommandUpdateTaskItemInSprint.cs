using Application.Command;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.TaskItemInSprint_s
{
    public record CommandUpdateTaskItemInSprint(
        Guid Id,
        TaskItemStatus? TaskStatus,
        string? Description,
        Guid? TaskItemId,
        Guid? SprintId
    ) : AbsCommandUpdateEntityById<TaskItemInSprint, TaskItemInSprintDto>(Id);
}
