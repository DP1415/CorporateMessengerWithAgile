using Application.AbsCommand.Update;
using Application.Dto.Summary;
using Domain.Entity;

namespace Application.Entity.TaskItems.Commands.TaskItemUpdate
{
    public record CommandUpdateTaskItem(
        Guid Id,
        string? Title,
        string? Description,
        int? Priority,
        int? Complexity,
        DateTime? Deadline,
        Guid? ProjectId,
        Guid? AuthorId,
        Guid? ResponsibleId,
        Guid? SprintWithLastMentionId,
        Guid? ParentTaskId
    ) : AbsCommandUpdateEntityById<TaskItem, TaskItemSummaryDto>(Id);
}
