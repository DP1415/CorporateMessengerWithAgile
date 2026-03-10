using Application.AbsQuery;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.TaskItems.Queries.TaskItemsGetByProject
{
    public class TaskItemsGetByProjectQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<TaskItemsGetByProjectQuery, TaskItem, IEnumerable<TaskItemSummaryDto>>(context, mapper)
    {
        public override async Task<IEnumerable<TaskItemSummaryDto>> Handle(
            TaskItemsGetByProjectQuery request,
            CancellationToken cancellationToken)
        {
            TaskItem[] taskItems = await _context.TaskItems
                .AsNoTracking()
                .Where(t => t.ProjectId == request.ProjectId)
                .Where(t => _context.TeamMembers
                    .Any(tm => tm.Team.ProjectId == t.ProjectId &&
                               tm.Employee.User.Id == request.CurrentUserId)
                )
                .Include(t => t.Project)
                .Include(t => t.Author)
                .Include(t => t.Responsible)
                .Include(t => t.SprintWithLastMention)
                .Include(t => t.ParentTask)
                .Include(t => t.Subtasks)
                .Include(t => t.TaskItemInSprints)
                .ToArrayAsync(cancellationToken);

            if (taskItems.Length == 0) return [];

            return _mapper.Map<TaskItemSummaryDto[]>(taskItems);
        }
    }
}
