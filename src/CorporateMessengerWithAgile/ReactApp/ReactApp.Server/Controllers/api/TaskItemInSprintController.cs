using Application.Dto;
using Application.Entity.TaskItemInSprint_s;
using Domain.Entity;
using MediatR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class TaskItemInSprintController(ISender sender) : ApiControllerBase
        <
            TaskItemInSprint,
            TaskItemInSprintDto,
            TaskItemsInSprintGetAllQuery,
            CommandCreateTaskItemInSprint,
            CommandUpdateTaskItemInSprint,
            CommandDeleteTaskItemInSprint
        >(
            sender,
            id => new CommandDeleteTaskItemInSprint(id)
        );
}
