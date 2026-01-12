using Application.AbsCommand.Delete;
using Domain.Entity;
using Persistence;

namespace Application.Entity.KanbanBoardColumns.Commands.KanbanBoardColumnDelete
{
    public class CommandDeleteKanbanBoardColumnHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteKanbanBoardColumn, KanbanBoardColumn>(context);
}
