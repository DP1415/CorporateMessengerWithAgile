using Application.Dto;
using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;

namespace Application.Entity.TaskItems.Queries.TaskItemsGetAll
{
    public record TaskItemsGetAllQuery()
        : AbsQueryEntityWithOptions<TaskItem, TaskItemDto>(
            [
                new Include<TaskItem, Project>(t => t.Project),
                new Include<TaskItem, Employee>(t => t.Author),
                new Include<TaskItem, Employee>(t => t.Responsible),
                new Include<TaskItem, Sprint>(t => t.SprintWithLastMention),
                new Include<TaskItem, TaskItem>(t => t.ParentTask),
                new Include<TaskItem, ICollection<TaskItem>>(t => t.Subtasks),
                new Include<TaskItem, ICollection<TaskItemInSprint>>(t => t.TaskItemInSprints)
            ]
        );
}
