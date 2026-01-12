using Application.AbsCommand.Delete;
using Domain.Entity;

namespace Application.Entity.KanbanBoardColumns.Commands.KanbanBoardColumnDelete
{
    public record CommandDeleteKanbanBoardColumn(Guid Id) : AbsCommandDeleteEntityById<KanbanBoardColumn>(Id);
}
