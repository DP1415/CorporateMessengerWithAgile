using Application.Dto;
using Application.Entity.KanbanBoardColumns;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KanbanBoardColumnController(ISender sender) : ApiController(sender)
    {
        [HttpGet]
        public async Task<IEnumerable<KanbanBoardColumnDto>> GetAll(
            CancellationToken cancellationToken = default)
            => await Sender.Send(new KanbanBoardColumnsGetAllQuery(), cancellationToken);

        [HttpPost]
        public async Task<Result<KanbanBoardColumnDto>> Create(
            [FromBody] CommandCreateKanbanBoardColumn command,
            CancellationToken cancellationToken = default)
            => await Sender.Send(command, cancellationToken);

        [HttpDelete("{id}")]
        public async Task<Result> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default)
            => await Sender.Send(new CommandDeleteKanbanBoardColumn(id), cancellationToken);

        [HttpPut]
        public async Task<Result<KanbanBoardColumnDto>> Change(
            [FromBody] CommandUpdateKanbanBoardColumn command,
            CancellationToken cancellationToken = default)
            => await Sender.Send(command, cancellationToken);
    }
}
