using Application.Dto;
using Application.Entity.Teams;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamController(ISender sender) : ApiController(sender)
    {
        [HttpGet]
        public async Task<IEnumerable<TeamDto>> GetAll(
            CancellationToken cancellationToken = default) =>
            await Sender.Send(new TeamsGetAllQuery(), cancellationToken);

        [HttpPost]
        public async Task<Result<TeamDto>> Create(
            [FromBody] CommandCreateTeam command,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(command, cancellationToken);

        [HttpDelete("{id}")]
        public async Task<Result> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(new CommandDeleteTeam(id), cancellationToken);

        [HttpPut]
        public async Task<Result<TeamDto>> Change(
            [FromBody] CommandUpdateTeam command,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(command, cancellationToken);
    }
}