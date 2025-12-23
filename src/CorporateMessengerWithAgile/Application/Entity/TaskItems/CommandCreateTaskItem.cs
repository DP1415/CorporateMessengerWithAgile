using Application.AbsCommand.Create;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.TaskItems
{
    public record CommandCreateTaskItem(
        string Title,
        string Description,
        int Priority,
        int Complexity,
        DateTime Deadline,
        Guid ProjectId,
        Guid AuthorId,
        Guid ResponsibleId,
        Guid? SprintWithLastMentionId = null,
        Guid? ParentTaskId = null
    ) : AbsCommandCreateEntity<TaskItem, TaskItemDto>;
}
