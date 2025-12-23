using Application.AbsCommand.Create;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.KanbanBoardColumns
{
    public record CommandCreateKanbanBoardColumn(
        string Title,
        TaskItemStatus TaskStatus,
        int PositionOnBoard,
        Guid TeamId
    ) : AbsCommandCreateEntity<KanbanBoardColumn, KanbanBoardColumnDto>;
}
