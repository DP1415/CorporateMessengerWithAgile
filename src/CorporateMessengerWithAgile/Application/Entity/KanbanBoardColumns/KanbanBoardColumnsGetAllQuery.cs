using Application.Dto;
using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;

namespace Application.Entity.KanbanBoardColumns
{
    public record KanbanBoardColumnsGetAllQuery()
        : AbsQuery<KanbanBoardColumn, KanbanBoardColumnDto>(
            [
                new Include<KanbanBoardColumn, Team>(col => col.Team)
            ]
        );
}
