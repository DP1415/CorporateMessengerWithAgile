using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;
using Application.Dto.Summary;

namespace Application.Entity.TaskItemInSprints.Queries.TaskItemsInSprintGetAll
{
    public record TaskItemsInSprintGetAllQuery()
        : AbsQueryEntityWithOptions<TaskItemInSprint, TaskItemInSprintSummaryDto>(
            [
                new Include<TaskItemInSprint, TaskItem>(t => t.TaskItem),
                new Include<TaskItemInSprint, Sprint>(t => t.Sprint)
            ]
        );
}
