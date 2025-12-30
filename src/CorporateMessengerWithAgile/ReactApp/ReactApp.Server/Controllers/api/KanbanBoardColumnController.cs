using Application.Dto;
using Application.Entity.KanbanBoardColumns;
using Domain.Entity;
using MediatR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class KanbanBoardColumnController(ISender sender) : ApiControllerBase
        <
            KanbanBoardColumn,
            KanbanBoardColumnDto,
            KanbanBoardColumnsGetAllQuery,
            CommandCreateKanbanBoardColumn,
            CommandUpdateKanbanBoardColumn,
            CommandDeleteKanbanBoardColumn
        >(
            sender,
            id => new CommandDeleteKanbanBoardColumn(id)
        );
}
