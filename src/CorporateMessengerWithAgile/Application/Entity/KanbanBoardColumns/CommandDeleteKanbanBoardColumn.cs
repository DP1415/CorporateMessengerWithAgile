using Application.AbsCommand.Delete;
using Domain.Entity;

namespace Application.Entity.KanbanBoardColumns
{
    public record CommandDeleteKanbanBoardColumn(Guid Id) : AbsCommandDeleteEntityById<KanbanBoardColumn>(Id);
}
