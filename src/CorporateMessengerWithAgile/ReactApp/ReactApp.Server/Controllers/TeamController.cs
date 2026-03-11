using Application.Dto;
using Application.Entity.Teams.Queries.TeamGetByIdWithDetails;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers
{
    [Route("cmwa/[controller]")]
    public class TeamController(ISender sender) : AuthorizedBaseController(sender)
    {
        [HttpGet("{teamId}")]
        public async Task<ActionResult<TeamWithRelationsDto>> GetTeamDetails(
            [FromRoute] Guid teamId,
            CancellationToken cancellationToken = default
        ) => (await SendAuth<TeamGetByIdWithDetailsQuery, Result<TeamWithRelationsDto>>(new TeamGetByIdWithDetailsQuery(teamId), cancellationToken)).ToActionResult();
    }
}
