using Application.AbsCommand.Create;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.TaskItems.Commands.TaskItemCreate
{
    public class CommandCreateTaskItemHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreateTaskItem, TaskItem, TaskItemSummaryDto>(context, mapper)
    {
        public override Result<TaskItem> Create(CommandCreateTaskItem request)
        {
            var title = Title.Create(request.Title);
            if (title.IsFailure) return title.Error;

            var description = Text.Create(request.Description);
            if (description.IsFailure) return description.Error;

            var taskItem = new TaskItem
            {
                Title = title,
                Description = description,
                Priority = request.Priority,
                Complexity = request.Complexity,
                Deadline = request.Deadline,
                ProjectId = request.ProjectId,
                AuthorId = request.AuthorId,
                ResponsibleId = request.ResponsibleId,
                SprintWithLastMentionId = request.SprintWithLastMentionId,
                ParentTaskId = request.ParentTaskId
            };

            return taskItem;
        }

        public override async Task<Result<TaskItemSummaryDto>> Handle(CommandCreateTaskItem request, CancellationToken cancellationToken)
        {
            var hasAccess = await _context.TeamMembers
                .AnyAsync(
                    tm =>
                        tm.Employee.User.Id == request.CurrentUserId &&
                        tm.Team.ProjectId == request.ProjectId,
                    cancellationToken);

            if (!hasAccess)
                return ApplicationErrors.ProjectError.AccessDenied(request.ProjectId);

            Result<TaskItem> entity = Create(request);
            if (entity.IsFailure) return entity.Error;

            await _dbSet.AddAsync(entity.Value, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TaskItemSummaryDto>(entity.Value);
        }
    }
}
