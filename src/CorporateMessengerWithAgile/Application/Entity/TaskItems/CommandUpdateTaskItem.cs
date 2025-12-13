using Application.Command;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.TaskItems
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
    ) : AbsCommandUpdateEntityById<TaskItem, TaskItemDto>(Id);
}
