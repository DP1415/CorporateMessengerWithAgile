using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Persistence;
using Domain.ValueObjects;
using Application.AbsCommand.Create;

namespace Application.Entity.TaskItemInSprint_s
{
    public class CommandCreateTaskItemInSprintHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreateTaskItemInSprint, TaskItemInSprint, TaskItemInSprintDto>(context, mapper)
    {
        public override Result<TaskItemInSprint> Create(CommandCreateTaskItemInSprint request)
        {
            var description = Text.Create(request.Description);
            if (description.IsFailure) return description.Error;

            var taskItemInSprint = new TaskItemInSprint
            {
                TaskStatus = request.TaskStatus,
                Description = description,
                TaskItemId = request.TaskItemId,
                SprintId = request.SprintId
            };

            return taskItemInSprint;
        }
    }
}
