using Application.AbsCommand.Create;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.TaskItemInSprints.Commands.TaskItemInSprintCreate
{
    public record CommandCreateTaskItemInSprint(
        TaskItemStatus TaskStatus,
        string Description,
        Guid TaskItemId,
        Guid SprintId
    ) : AbsCommandCreateEntity<TaskItemInSprint, TaskItemInSprintDto>;
}
