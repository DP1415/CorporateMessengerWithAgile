using Application.Dto;
using Application.Entity.TaskItems;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Abstract;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskItemController(ISender sender) : ApiController(sender)
    {
        [HttpGet]
        public async Task<IEnumerable<TaskItemDto>> GetAll(
            CancellationToken cancellationToken = default) =>
            await Sender.Send(new TaskItemsGetAllQuery(), cancellationToken);

        [HttpPost]
        public async Task<Result<TaskItemDto>> Create(
            [FromBody] CommandCreateTaskItem command,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(command, cancellationToken);

        [HttpDelete("{id}")]
        public async Task<Result> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(new CommandDeleteTaskItem(id), cancellationToken);

        [HttpPut]
        public async Task<Result<TaskItemDto>> Change(
            [FromBody] CommandUpdateTaskItem command,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(command, cancellationToken);
    }
}
