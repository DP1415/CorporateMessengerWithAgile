using Application.AbsQuery;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.TaskItems.Queries.TaskItemsGetBySprint
{
    public class TaskItemsGetBySprintQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityHandler<TaskItemsGetBySprintQuery, TaskItem, IEnumerable<TaskItemSummaryDto>>(context, mapper)
    {
        public override async Task<IEnumerable<TaskItemSummaryDto>> Handle(
            TaskItemsGetBySprintQuery request,
            CancellationToken cancellationToken)
        {
            TaskItemInSprint[] taskItemInSprints = await _context.TaskItemInSprints
                .AsTracking()
                .Where(tis => tis.SprintId == request.SprintId)
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
