using Application.Dto;
using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;

namespace Application.Entity.KanbanBoardColumns.Queries.KanbanBoardColumnsGetAll
{
    public record KanbanBoardColumnsGetAllQuery()
        : AbsQueryEntityWithOptions<KanbanBoardColumn, KanbanBoardColumnDto>(
            [
                new Include<KanbanBoardColumn, Team>(col => col.Team)
            ]
        );
}
