using Application.AbsQuery;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.TaskItems.Queries.TaskItemsGetBySprintWithStatus
{
    public record TaskItemsGetBySprintWithStatusQuery
        (
            Guid SprintId
        )
        : AbsAuthorizedQuery<TaskItemInSprint, IEnumerable<TaskItemWithStatusDto>>;
}
