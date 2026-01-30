using Application.AbsCommand.Update;
using Application.Dto.Summary;
using Domain.Entity;

namespace Application.Entity.TaskItemInSprints.Commands.TaskItemInSprintUpdate
{
    public record CommandUpdateTaskItemInSprint(
        Guid Id,
        TaskItemStatus? TaskStatus,
        string? Description,
        Guid? TaskItemId,
        Guid? SprintId
    ) : AbsCommandUpdateEntityById<TaskItemInSprint, TaskItemInSprintSummaryDto>(Id);
}
