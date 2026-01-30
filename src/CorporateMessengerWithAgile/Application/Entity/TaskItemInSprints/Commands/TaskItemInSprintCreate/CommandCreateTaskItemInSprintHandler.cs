using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Persistence;
using Domain.ValueObjects;
using Application.AbsCommand.Create;
using Application.Dto.Summary;

namespace Application.Entity.TaskItemInSprints.Commands.TaskItemInSprintCreate
{
    public class CommandCreateTaskItemInSprintHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreateTaskItemInSprint, TaskItemInSprint, TaskItemInSprintSummaryDto>(context, mapper)
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
