using Application.Dto;
using Application.Entity.TaskItemInSprint_s;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class TaskItemInSprintController(ISender sender) : ApiControllerBase(sender)
    {
        [HttpGet]
        public async Task<IEnumerable<TaskItemInSprintDto>> GetAll(
            CancellationToken cancellationToken = default) =>
            await Sender.Send(new TaskItemsInSprintGetAllQuery(), cancellationToken);

        [HttpPost]
        public async Task<Result<TaskItemInSprintDto>> Create(
            [FromBody] CommandCreateTaskItemInSprint command,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(command, cancellationToken);

        [HttpDelete("{id}")]
        public async Task<Result> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(new CommandDeleteTaskItemInSprint(id), cancellationToken);

        [HttpPut]
        public async Task<Result<TaskItemInSprintDto>> Change(
            [FromBody] CommandUpdateTaskItemInSprint command,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(command, cancellationToken);
    }
}
