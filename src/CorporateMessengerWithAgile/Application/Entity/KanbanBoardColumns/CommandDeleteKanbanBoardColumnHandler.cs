using Application.Command;
using Domain.Entity;
using Persistence;

namespace Application.Entity.KanbanBoardColumns
{
    public class CommandDeleteKanbanBoardColumnHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteKanbanBoardColumn, KanbanBoardColumn>(context);
}
