using Application.AbsCommand.Create;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.KanbanBoardColumns
{
    public class CommandCreateKanbanBoardColumnHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreateKanbanBoardColumn, KanbanBoardColumn, KanbanBoardColumnDto>(context, mapper)
    {
        public override Result<KanbanBoardColumn> Create(CommandCreateKanbanBoardColumn request)
        {
            var title = Title.Create(request.Title);
            if (title.IsFailure) return title.Error;

            var column = new KanbanBoardColumn
            {
                Title = title,
                TaskStatus = request.TaskStatus,
                PositionOnBoard = request.PositionOnBoard,
                TeamId = request.TeamId
            };

            return column;
        }
    }
}
