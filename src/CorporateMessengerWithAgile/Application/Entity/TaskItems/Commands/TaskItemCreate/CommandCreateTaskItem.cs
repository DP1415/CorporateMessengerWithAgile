using Application.AbsCommand.Create;
using Application.Dto.Summary;
using Domain.Entity;

namespace Application.Entity.TaskItems.Commands.TaskItemCreate
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
    ) : AbsCommandCreateEntity<TaskItem, TaskItemSummaryDto>;
}
