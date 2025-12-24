using Application.AbsCommand.Update;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.KanbanBoardColumns
{
    public record CommandUpdateKanbanBoardColumn(
        Guid Id,
        string? Title,
        TaskItemStatus? TaskStatus,
        int? PositionOnBoard,
        Guid? TeamId
    ) : AbsCommandUpdateEntityById<KanbanBoardColumn, KanbanBoardColumnDto>(Id);
}
