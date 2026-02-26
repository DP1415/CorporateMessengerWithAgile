using Application.AbsQuery;
using Application.Dto;
using Application.Dto.Summary;
using Application.Entity.Employees.Queries.EmployeeGetByUserId;
using Application.Entity.Sprints.Queries.SprintsGetByTeam;
using Application.Entity.TaskItems.Commands.TaskItemCreate;
using Application.Entity.TaskItems.Queries.TaskItemsGetByProject;
using Application.Entity.TaskItems.Queries.TaskItemsGetBySprint;
using Application.Entity.TaskItems.Queries.TaskItemsGetBySprintWithStatus;
using Application.Entity.Teams.Queries.TeamGetByIdWithDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;
using System.Security.Claims;

namespace ReactApp.Server.Controllers
{
    [Authorize]
    [Route("cmwa/[controller]")]
    public class UserController(ISender sender) : AbstractController(sender)
    {
        protected override async Task<TResponse> Send<TResponse>(
            AbsQuery<TResponse> request,
            CancellationToken cancellationToken)
        {
            var currentUserId = User.FindFirstValue("currentUserId");
            if (!Guid.TryParse(currentUserId, out var userId)) throw new UnauthorizedAccessException("Неверный или отсутствующий ID пользователя");
            request.CurrentUserId = userId;
            return await base.Send(request, cancellationToken);
        }

        [HttpGet("employees")]
        public Task<IEnumerable<EmployeeWithRelations>> GetEmployeesByUserId(CancellationToken cancellationToken)
            => Send(new EmployeeGetByUserIdQuery(), cancellationToken);

        [HttpGet("teams/{teamId}/")]
        public async Task<ActionResult<TeamWithRelationsDto>> GetTeamDetails(
            [FromRoute] Guid teamId,
            CancellationToken cancellationToken = default
        ) => (await Sender.Send(new TeamGetByIdWithDetailsQuery(teamId), cancellationToken)).ToActionResult();

        [HttpGet("task-items/get-by-project/{projectId}")]
        public async Task<IEnumerable<TaskItemSummaryDto>> GetTaskItemsByProject(
            [FromRoute] Guid projectId,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new TaskItemsGetByProjectQuery(projectId), cancellationToken);

        [HttpGet("teams/{teamId}/sprints")]
        public async Task<IEnumerable<SprintSummaryDto>> GetSprintsByTeam(
            [FromRoute] Guid teamId,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new SprintsGetByTeamQuery(teamId), cancellationToken);

        [HttpGet("sprints/{sprintId}/task-items")]
        public async Task<IEnumerable<TaskItemSummaryDto>> GetTaskItemsBySprint(
            [FromRoute] Guid sprintId,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new TaskItemsGetBySprintQuery(sprintId), cancellationToken);

        [HttpGet("sprints/{sprintId}/task-items-with-status")]
        public async Task<IEnumerable<TaskItemWithStatusDto>> GetTaskItemsBySprintWithStatus(
            [FromRoute] Guid sprintId,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new TaskItemsGetBySprintWithStatusQuery(sprintId), cancellationToken);

        [HttpPost("task-items/create")]
        public async Task<ActionResult<TaskItemSummaryDto>> CreateTaskItem(
            [FromBody] CreateTaskItemRequest request,
            CancellationToken cancellationToken = default
        )
        {
            var result = await Sender.Send(new CommandCreateTaskItem(
                request.Title,
                request.Description,
                request.Priority,
                request.Complexity,
                request.Deadline,
                request.ProjectId,
                request.AuthorId,
                request.ResponsibleId,
                request.SprintWithLastMentionId,
                request.ParentTaskId
            ), cancellationToken);

            return result.ToActionResult();
        }
    }

    public class CreateTaskItemRequest
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Priority { get; set; }
        public int Complexity { get; set; }
        public DateTime Deadline { get; set; }
        public Guid ProjectId { get; set; }
        public Guid AuthorId { get; set; }
        public Guid ResponsibleId { get; set; }
        public Guid? SprintWithLastMentionId { get; set; }
        public Guid? ParentTaskId { get; set; }
    }
}
