using Application.AbsQuery;
using Domain.Entity;
using Application.Dto.Summary;

namespace Application.Entity.TaskItems.Queries.TaskItemsGetBySprint
{
    public record TaskItemsGetBySprintQuery
        (
            Guid SprintId
        )
        : AbsQueryEntity<TaskItem, IEnumerable<TaskItemSummaryDto>>;
}
