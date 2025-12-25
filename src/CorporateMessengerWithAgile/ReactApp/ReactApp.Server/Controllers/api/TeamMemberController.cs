using Application.Dto;
using Application.Entity.TeamMembers;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamMemberController(ISender sender) : ApiController(sender)
    {
        [HttpGet]
        public async Task<IEnumerable<TeamMemberDto>> GetAll(
            CancellationToken cancellationToken = default) =>
            await Sender.Send(new TeamMembersGetAllQuery(), cancellationToken);

        [HttpPost]
        public async Task<Result<TeamMemberDto>> Create(
            [FromBody] CommandCreateTeamMember command,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(command, cancellationToken);

        [HttpDelete("{id}")]
        public async Task<Result> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(new CommandDeleteTeamMember(id), cancellationToken);

        [HttpPut]
        public async Task<Result<TeamMemberDto>> Change(
            [FromBody] CommandUpdateTeamMember command,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(command, cancellationToken);
    }
}