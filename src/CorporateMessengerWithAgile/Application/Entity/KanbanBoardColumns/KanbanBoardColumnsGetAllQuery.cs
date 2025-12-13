using Application.Dto;
using Application.Query.Options;
using Application.Query;
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
