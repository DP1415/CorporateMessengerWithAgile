using Application.Dto;
using Application.Dto.Summary;
using Application.Entity.Employees.Queries.EmployeeGetByUserId;
using Application.Entity.Sprints.Queries.SprintsGetByTeam;
using Application.Entity.TaskItems.Commands.TaskItemCreate;
using Application.Entity.TaskItems.Queries.TaskItemsGetByProject;
using Application.Entity.TaskItems.Queries.TaskItemsGetBySprint;
using Application.Entity.TaskItems.Queries.TaskItemsGetBySprintWithStatus;
using Application.Entity.Teams.Queries.TeamGetByIdWithDetails;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers
{
    [Route("cmwa/[controller]")]
    public class UserController(ISender sender) : AuthorizedBaseController(sender)
    {
        [HttpGet("employees")]
        public Task<IEnumerable<EmployeeWithRelations>> GetEmployeesByUserId(CancellationToken cancellationToken)
            => SendAuth<EmployeeGetByUserIdQuery, IEnumerable<EmployeeWithRelations>>(new EmployeeGetByUserIdQuery(), cancellationToken);

        [HttpGet("teams/{teamId}/")]
        public async Task<ActionResult<TeamWithRelationsDto>> GetTeamDetails(
            [FromRoute] Guid teamId,
            CancellationToken cancellationToken = default
        ) => (await SendAuth<TeamGetByIdWithDetailsQuery, Result<TeamWithRelationsDto>>(new TeamGetByIdWithDetailsQuery(teamId), cancellationToken)).ToActionResult();

        [HttpGet("task-items/get-by-project/{projectId}")]
        public async Task<IEnumerable<TaskItemSummaryDto>> GetTaskItemsByProject(
            [FromRoute] Guid projectId,
            CancellationToken cancellationToken = default
        ) => await SendAuth<TaskItemsGetByProjectQuery, IEnumerable<TaskItemSummaryDto>>(new TaskItemsGetByProjectQuery(projectId), cancellationToken);

        [HttpGet("teams/{teamId}/sprints")]
        public async Task<IEnumerable<SprintSummaryDto>> GetSprintsByTeam(
            [FromRoute] Guid teamId,
            CancellationToken cancellationToken = default
        ) => await SendAuth<SprintsGetByTeamQuery, IEnumerable<SprintSummaryDto>>(new SprintsGetByTeamQuery(teamId), cancellationToken);

        [HttpGet("sprints/{sprintId}/task-items")]
        public async Task<IEnumerable<TaskItemSummaryDto>> GetTaskItemsBySprint(
            [FromRoute] Guid sprintId,
            CancellationToken cancellationToken = default
        ) => await SendAuth<TaskItemsGetBySprintQuery, IEnumerable<TaskItemSummaryDto>>(new TaskItemsGetBySprintQuery(sprintId), cancellationToken);

        [HttpGet("sprints/{sprintId}/task-items-with-status")]
        public async Task<IEnumerable<TaskItemWithStatusDto>> GetTaskItemsBySprintWithStatus(
            [FromRoute] Guid sprintId,
            CancellationToken cancellationToken = default
        ) => await SendAuth<TaskItemsGetBySprintWithStatusQuery, IEnumerable<TaskItemWithStatusDto>>(new TaskItemsGetBySprintWithStatusQuery(sprintId), cancellationToken);

        [HttpPost("task-items/create")]
        public async Task<ActionResult<TaskItemSummaryDto>> CreateTaskItem(
            [FromBody] CommandCreateTaskItem request,
            CancellationToken cancellationToken = default
        ) => (await SendAuth<CommandCreateTaskItem, Result<TaskItemSummaryDto>>(request, cancellationToken)).ToActionResult();
    }
}
