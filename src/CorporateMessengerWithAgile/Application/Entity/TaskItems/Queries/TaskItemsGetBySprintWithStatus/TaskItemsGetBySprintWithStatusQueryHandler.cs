using Application.AbsQuery;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.TaskItems.Queries.TaskItemsGetBySprintWithStatus
{
    // Изменили базовый класс, так как теперь работаем с TaskItemInSprint
    public class TaskItemsGetBySprintWithStatusQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<TaskItemsGetBySprintWithStatusQuery, TaskItemInSprint, IEnumerable<TaskItemWithStatusDto>>(context, mapper)
    {
        public override async Task<IEnumerable<TaskItemWithStatusDto>> Handle(
            TaskItemsGetBySprintWithStatusQuery request,
            CancellationToken cancellationToken)
        {
            // Загружаем TaskItemInSprint, связанный с нужным спринтом
            // Подключаем TaskItem и его связи для мапинга основных данных задачи
            TaskItemInSprint[] taskItemsInSprints = await _context.TaskItemInSprints
                .AsNoTracking()
                .Where(tis => tis.SprintId == request.SprintId)
                .Join(_context.Sprints
                    .Where(s => _context.TeamMembers
                        .Any(tm => tm.Employee.User.Id == request.CurrentUserId && tm.TeamId == s.TeamId))
                    .Select(s => s.Id),
                    tis => tis.SprintId,
                    sprintId => sprintId,
                    (tis, _) => tis)
                .Include(tis => tis.TaskItem)
                    .ThenInclude(ti => ti.Project)
                .Include(tis => tis.TaskItem)
                    .ThenInclude(ti => ti.Author)
                .Include(tis => tis.TaskItem)
                    .ThenInclude(ti => ti.Responsible)
                .Include(tis => tis.TaskItem)
                    .ThenInclude(ti => ti.SprintWithLastMention)
                .Include(tis => tis.TaskItem)
                    .ThenInclude(ti => ti.ParentTask)
                .Include(tis => tis.TaskItem)
                    .ThenInclude(ti => ti.Subtasks)
                .ToArrayAsync(cancellationToken);

            if (taskItemsInSprints.Length == 0) return [];

            return _mapper.Map<TaskItemWithStatusDto[]>(taskItemsInSprints);
        }
    }
}