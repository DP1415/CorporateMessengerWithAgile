using Application.AbsQuery;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.TaskItems.Queries.TaskItemsGetBySprint
{
    public class TaskItemsGetBySprintQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<TaskItemsGetBySprintQuery, TaskItem, IEnumerable<TaskItemSummaryDto>>(context, mapper)
    {
        public override async Task<IEnumerable<TaskItemSummaryDto>> Handle(
            TaskItemsGetBySprintQuery request,
            CancellationToken cancellationToken)
        {
            var authorizedTeamMemberIds = _context.TeamMembers
                .Where(tm => tm.Employee.User.Id == request.CurrentUserId)
                .Select(tm => tm.Id);

            TaskItemInSprint[] taskItemInSprints = await _context.TaskItemInSprints
                .AsTracking()
                .Where(tis => tis.SprintId == request.SprintId)
                .Join(_context.Sprints
                    .Where(s => _context.TeamMembers
                        .Any(tm => tm.Employee.User.Id == request.CurrentUserId && tm.TeamId == s.TeamId))
                    .Select(s => s.Id),
                    tis => tis.SprintId,
                    sprintId => sprintId,
                    (tis, _) => tis)
                .Include(tis => tis.TaskItem)
                    .ThenInclude(t => t.Project)
                .Include(tis => tis.TaskItem.Author)
                .Include(tis => tis.TaskItem.Responsible)
                .Include(tis => tis.TaskItem.SprintWithLastMention)
                .Include(tis => tis.TaskItem.ParentTask)
                .Include(tis => tis.TaskItem.Subtasks)
                .Include(tis => tis.TaskItem.TaskItemInSprints)
                .ToArrayAsync(cancellationToken);

            if (taskItemInSprints.Length == 0) return [];

            return _mapper.Map<TaskItemSummaryDto[]>(taskItemInSprints.Select(tis => tis.TaskItem));
        }
    }
}
