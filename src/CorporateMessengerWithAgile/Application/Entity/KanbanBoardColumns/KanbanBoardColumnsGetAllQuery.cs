using Application.Dto;
using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;

namespace Application.Entity.KanbanBoardColumns
{
    public record KanbanBoardColumnsGetAllQuery()
        : AbsQueryGetAllEntity<KanbanBoardColumn, KanbanBoardColumnDto>(
            [
                new Include<KanbanBoardColumn, Team>(col => col.Team)
            ]
        );
}
