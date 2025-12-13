using Application.Command;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.TaskItems
{
    public class CommandUpdateTaskItemHandler(AppDbContext context, IMapper mapper)
        : AbsCommandUpdateEntityByIdHandler<CommandUpdateTaskItem, TaskItem, TaskItemDto>(context, mapper)
    {
        protected override Result<TaskItem> Update(TaskItem entity, CommandUpdateTaskItem request)
        {
            if (request.Title is not null)
            {
                var title = Title.Create(request.Title);
                if (title.IsFailure) return title.Exception;
                entity.Title = title;
            }

            if (request.Description is not null)
            {
                var description = Text.Create(request.Description);
                if (description.IsFailure) return description.Exception;
                entity.Description = description;
            }

            if (request.Priority.HasValue)
                entity.Priority = request.Priority.Value;

            if (request.Complexity.HasValue)
                entity.Complexity = request.Complexity.Value;

            if (request.Deadline.HasValue)
                entity.Deadline = request.Deadline.Value;

            if (request.ProjectId.HasValue)
                entity.ProjectId = request.ProjectId.Value;

            if (request.AuthorId.HasValue)
                entity.AuthorId = request.AuthorId.Value;

            if (request.ResponsibleId.HasValue)
                entity.ResponsibleId = request.ResponsibleId.Value;

            if (request.SprintWithLastMentionId.HasValue)
                entity.SprintWithLastMentionId = request.SprintWithLastMentionId.Value;

            if (request.ParentTaskId.HasValue)
                entity.ParentTaskId = request.ParentTaskId.Value;

            return entity;
        }
    }
}
