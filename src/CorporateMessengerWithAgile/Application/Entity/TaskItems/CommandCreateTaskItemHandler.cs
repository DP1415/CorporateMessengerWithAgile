using Application.AbsCommand.Create;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.TaskItems
{
    public class CommandCreateTaskItemHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreateTaskItem, TaskItem, TaskItemDto>(context, mapper)
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
    }
}
