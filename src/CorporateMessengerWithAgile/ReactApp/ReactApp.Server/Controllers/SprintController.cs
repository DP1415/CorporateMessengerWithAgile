using Application.Dto.Summary;
using Application.Entity.Sprints.Queries.SprintsGetByTeam;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers
{
    [Route("cmwa/[controller]")]
    public class SprintController(ISender sender) : AuthorizedBaseController(sender)
    {
        [HttpGet("team/{teamId}")]
        public async Task<IEnumerable<SprintSummaryDto>> GetSprintsByTeam(
            [FromRoute] Guid teamId,
            CancellationToken cancellationToken = default
        ) => await SendAuth<SprintsGetByTeamQuery, IEnumerable<SprintSummaryDto>>(new SprintsGetByTeamQuery(teamId), cancellationToken);

    }
}
