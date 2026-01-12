using Application.Dto;
using Application.Entity.TaskItems.Commands.TaskItemCreate;
using Application.Entity.TaskItems.Commands.TaskItemDelete;
using Application.Entity.TaskItems.Commands.TaskItemUpdate;
using Application.Entity.TaskItems.Queries.TaskItemsGetAll;
using Domain.Entity;
using MediatR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class TaskItemController(ISender sender) : ApiControllerBase
        <
            TaskItem,
            TaskItemDto,
            TaskItemsGetAllQuery,
            CommandCreateTaskItem,
            CommandUpdateTaskItem,
            CommandDeleteTaskItem
        >(
            sender,
            id => new CommandDeleteTaskItem(id)
        );
}
