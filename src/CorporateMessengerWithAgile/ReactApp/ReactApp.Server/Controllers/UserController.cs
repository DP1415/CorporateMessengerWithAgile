using Application.Dto;
using Application.Dto.Summary;
using Application.Entity.Employees.Queries.EmployeeGetByUserId;
using Application.Entity.TaskItems.Queries.TaskItemsGetByProject;
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
        public async Task<IEnumerable<EmployeeWithRelations>> GetEmployeesByUserId(
            [FromRoute] Guid userId,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new EmployeeGetByUserIdQuery(userId), cancellationToken);

        [Authorize]
        [HttpGet("teams/{teamId}/")]
        public async Task<ActionResult<TeamWithRelationsDto>> GetTeamDetails(
            [FromRoute] Guid teamId,
            CancellationToken cancellationToken = default
        ) => (await Sender.Send(new TeamGetByIdWithDetailsQuery(teamId), cancellationToken)).ToActionResult();

        [Authorize]
        [HttpGet("task-items/get-by-project/{projectId}")]
        public async Task<IEnumerable<TaskItemSummaryDto>> GetTaskItemsByProject(
            [FromRoute] Guid projectId,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new TaskItemsGetByProjectQuery(projectId), cancellationToken);
    }
}
