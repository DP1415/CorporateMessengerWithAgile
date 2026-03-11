using Application.Dto;
using Application.Dto.Summary;
using Application.Entity.TaskItems.Commands.TaskItemCreate;
using Application.Entity.TaskItems.Queries.TaskItemsGetByProject;
using Application.Entity.TaskItems.Queries.TaskItemsGetBySprint;
using Application.Entity.TaskItems.Queries.TaskItemsGetBySprintWithStatus;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers
{
    [Route("cmwa/[controller]")]
    public class TaskController(ISender sender) : AuthorizedBaseController(sender)
    {
        [HttpGet("sprint/{sprintId}/task-items-with-status")]
        public async Task<IEnumerable<TaskItemWithStatusDto>> GetTaskItemsBySprintWithStatus(
            [FromRoute] Guid sprintId,
            CancellationToken cancellationToken = default
        ) => await SendAuth<TaskItemsGetBySprintWithStatusQuery, IEnumerable<TaskItemWithStatusDto>>(new TaskItemsGetBySprintWithStatusQuery(sprintId), cancellationToken);

        [HttpGet("sprint/{sprintId}/task-items")]
        public async Task<IEnumerable<TaskItemSummaryDto>> GetTaskItemsBySprint(
            [FromRoute] Guid sprintId,
            CancellationToken cancellationToken = default
        ) => await SendAuth<TaskItemsGetBySprintQuery, IEnumerable<TaskItemSummaryDto>>(new TaskItemsGetBySprintQuery(sprintId), cancellationToken);

        [HttpGet("project/{projectId}")]
        public async Task<IEnumerable<TaskItemSummaryDto>> GetTaskItemsByProject(
            [FromRoute] Guid projectId,
            CancellationToken cancellationToken = default
        ) => await SendAuth<TaskItemsGetByProjectQuery, IEnumerable<TaskItemSummaryDto>>(new TaskItemsGetByProjectQuery(projectId), cancellationToken);

        [HttpPost]
        public async Task<ActionResult<TaskItemSummaryDto>> CreateTaskItem(
            [FromBody] CommandCreateTaskItem request,
            CancellationToken cancellationToken = default
        ) => (await SendAuth<CommandCreateTaskItem, Result<TaskItemSummaryDto>>(request, cancellationToken)).ToActionResult();
    }
}
