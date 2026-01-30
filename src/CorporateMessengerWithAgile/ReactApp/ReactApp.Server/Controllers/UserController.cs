using Application.Dto;
using Application.Entity.Employees.Queries.EmployeeGetByUserId;
using Application.Entity.Employees.Queries.EmployeeGetProjectsAndTeams;
using Application.Entity.Teams.Queries.TeamGetByIdWithDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers
{
    [Route("cmwa/[controller]")]
    public class UserController(ISender sender) : AbstractController(sender)
    {
        [Authorize]
        [HttpGet("{userId}/employees")]
        public async Task<IEnumerable<EmployeeWithRelationsDto>> GetEmployeesByUserId(
            [FromRoute] Guid userId,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new EmployeeGetByUserIdQuery(userId), cancellationToken);

        [Authorize]
        [HttpGet("{employeeId}/projects-and-teams")]
        public async Task<IEnumerable<ProjectWithTeams>> GetProjectsAndTeamsByEmployeeId(
            [FromRoute] Guid employeeId,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new EmployeeGetProjectsAndTeamsQuery(employeeId), cancellationToken);

        [Authorize]
        [HttpGet("teams/{teamId}/")]
        public async Task<ActionResult<TeamWithRelationsDto>> GetTeamDetails(
            [FromRoute] Guid teamId,
            CancellationToken cancellationToken = default
        ) => (await Sender.Send(new TeamGetByIdWithDetailsQuery(teamId), cancellationToken)).ToActionResult();
    }
}
