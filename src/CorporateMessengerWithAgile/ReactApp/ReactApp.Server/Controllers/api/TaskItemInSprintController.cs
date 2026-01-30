using Application.Dto.Summary;
using Application.Entity.TaskItemInSprints.Commands.TaskItemInSprintCreate;
using Application.Entity.TaskItemInSprints.Commands.TaskItemInSprintDelete;
using Application.Entity.TaskItemInSprints.Commands.TaskItemInSprintUpdate;
using Application.Entity.TaskItemInSprints.Queries.TaskItemsInSprintGetAll;
using Domain.Entity;
using MediatR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class TaskItemInSprintController(ISender sender) : ApiControllerBase
        <
            TaskItemInSprint,
            TaskItemInSprintSummaryDto,
            TaskItemsInSprintGetAllQuery,
            CommandCreateTaskItemInSprint,
            CommandUpdateTaskItemInSprint,
            CommandDeleteTaskItemInSprint
        >(
            sender,
            id => new CommandDeleteTaskItemInSprint(id)
        );
}
