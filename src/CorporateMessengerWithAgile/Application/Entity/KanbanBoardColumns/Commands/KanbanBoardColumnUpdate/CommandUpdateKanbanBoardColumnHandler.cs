using Application.AbsCommand.Update;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.KanbanBoardColumns.Commands.KanbanBoardColumnUpdate
{
    public class CommandUpdateKanbanBoardColumnHandler(AppDbContext context, IMapper mapper)
        : AbsCommandUpdateEntityByIdHandler<CommandUpdateKanbanBoardColumn, KanbanBoardColumn, KanbanBoardColumnDto>(context, mapper)
    {
        protected override Result<KanbanBoardColumn> Update(KanbanBoardColumn entity, CommandUpdateKanbanBoardColumn request)
        {
            if (request.Title is not null)
            {
                var title = Title.Create(request.Title);
                if (title.IsFailure) return title.Error;
                entity.Title = title;
            }

            if (request.TaskStatus.HasValue)
            {
                entity.TaskStatus = request.TaskStatus.Value;
            }

            if (request.PositionOnBoard.HasValue)
            {
                entity.PositionOnBoard = request.PositionOnBoard.Value;
            }

            if (request.TeamId.HasValue)
            {
                entity.TeamId = request.TeamId.Value;
                // Опционально: можно загрузить Team из БД, если нужно (но это может быть избыточно на уровне команды)
            }

            return entity;
        }
    }
}
