using Application.AbsCommand.Create;
using Application.Dto.Summary;
using Domain.Entity;

namespace Application.Entity.KanbanBoardColumns.Commands.KanbanBoardColumnCreate
{
    public record CommandCreateKanbanBoardColumn(
        string Title,
        TaskItemStatus TaskStatus,
        int PositionOnBoard,
        Guid TeamId
    ) : AbsCommandCreateEntity<KanbanBoardColumn, KanbanBoardColumnSummaryDto>;
}
