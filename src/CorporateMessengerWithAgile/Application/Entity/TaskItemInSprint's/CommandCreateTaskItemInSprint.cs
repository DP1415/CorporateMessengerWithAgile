using Application.Command;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.TaskItemInSprint_s
{
    public record CommandCreateTaskItemInSprint(
        TaskItemStatus TaskStatus,
        string Description,
        Guid TaskItemId,
        Guid SprintId
    ) : AbsCommandCreateEntity<TaskItemInSprint, TaskItemInSprintDto>;
}
