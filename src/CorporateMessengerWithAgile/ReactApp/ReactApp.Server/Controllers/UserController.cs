using Application.Dto;
using Application.Entity.Employees.Queries.EmployeeGetByUserId;
using Application.Entity.Employees.Queries.EmployeeGetProjectsAndTeams;
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
        public async Task<IEnumerable<WorkplaceDto>> GetEmployeesByUserId(
            [FromRoute] Guid userId,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new EmployeeGetByUserIdQuery(userId), cancellationToken);

        [Authorize]
        [HttpGet("{employeeId}/projects-and-teams")]
        public async Task<EmployeeProjectsAndTeamsDto> GetProjectsAndTeamsByEmployeeId(
            [FromRoute] Guid employeeId,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new EmployeeGetProjectsAndTeamsQuery(employeeId), cancellationToken);
    }
}
