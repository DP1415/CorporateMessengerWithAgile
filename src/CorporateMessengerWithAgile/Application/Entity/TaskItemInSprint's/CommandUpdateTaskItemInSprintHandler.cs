using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Persistence;
using Domain.ValueObjects;
using Application.AbsCommand.Update;

namespace Application.Entity.TaskItemInSprint_s
{
    public class CommandUpdateTaskItemInSprintHandler(AppDbContext context, IMapper mapper)
        : AbsCommandUpdateEntityByIdHandler<CommandUpdateTaskItemInSprint, TaskItemInSprint, TaskItemInSprintDto>(context, mapper)
    {
        protected override Result<TaskItemInSprint> Update(TaskItemInSprint entity, CommandUpdateTaskItemInSprint request)
        {
            if (request.TaskStatus is not null)
                entity.TaskStatus = request.TaskStatus.Value;

            if (request.Description is not null)
            {
                var description = Text.Create(request.Description);
                if (description.IsFailure) return description.Error;
                entity.Description = description;
            }

            if (request.TaskItemId.HasValue)
                entity.TaskItemId = request.TaskItemId.Value;

            if (request.SprintId.HasValue)
                entity.SprintId = request.SprintId.Value;

            return entity;
        }
    }
}
