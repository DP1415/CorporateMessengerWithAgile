using Application.AbsQuery;
using Application.AbsQuery.Options;
using Domain.Entity;
using Application.Dto.Summary;

namespace Application.Entity.TaskItems.Queries.TaskItemsGetByProject
{
    public record TaskItemsGetByProjectQuery
        (
            Guid ProjectId
        )
        : AbsQuery<TaskItem, IEnumerable<TaskItemSummaryDto>>;
}
