using Application.Dto;
using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;

namespace Application.Entity.TaskItemInSprints.Queries.TaskItemsInSprintGetAll
{
    public record TaskItemsInSprintGetAllQuery()
        : AbsQueryEntityWithOptions<TaskItemInSprint, TaskItemInSprintDto>(
            [
                new Include<TaskItemInSprint, TaskItem>(t => t.TaskItem),
                new Include<TaskItemInSprint, Sprint>(t => t.Sprint)
            ]
        );
}
