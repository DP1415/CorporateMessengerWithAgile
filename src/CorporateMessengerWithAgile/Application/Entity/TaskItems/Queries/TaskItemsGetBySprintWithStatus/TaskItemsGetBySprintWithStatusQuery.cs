using Application.AbsQuery;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.TaskItems.Queries.TaskItemsGetBySprintWithStatus
{
    public record TaskItemsGetBySprintWithStatusQuery
        (
            Guid SprintId
        )
        : AbsQueryEntity<TaskItemInSprint, IEnumerable<TaskItemWithStatusDto>>;
}
