using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;
using Application.Dto.Summary;

namespace Application.Entity.KanbanBoardColumns.Queries.KanbanBoardColumnsGetAll
{
    public record KanbanBoardColumnsGetAllQuery()
        : AbsQueryEntityWithOptions<KanbanBoardColumn, KanbanBoardColumnSummaryDto>(
            [
                new Include<KanbanBoardColumn, Team>(col => col.Team)
            ]
        );
}
