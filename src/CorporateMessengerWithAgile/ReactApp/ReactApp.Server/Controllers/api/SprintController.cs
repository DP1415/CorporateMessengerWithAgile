using Application.Dto;
using Application.Entity.Sprints;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class SprintController(ISender sender) : ApiController(sender)
    {
        [HttpGet]
        public async Task<IEnumerable<SprintDto>> GetAll(
            CancellationToken cancellationToken = default) =>
            await Sender.Send(new SprintsGetAllQuery(), cancellationToken);

        [HttpPost]
        public async Task<Result<SprintDto>> Create(
            [FromBody] CommandCreateSprint command,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(command, cancellationToken);

        [HttpDelete("{id}")]
        public async Task<Result> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(new CommandDeleteSprint(id), cancellationToken);

        [HttpPut]
        public async Task<Result<SprintDto>> Change(
            [FromBody] CommandUpdateSprint command,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(command, cancellationToken);
    }
}
