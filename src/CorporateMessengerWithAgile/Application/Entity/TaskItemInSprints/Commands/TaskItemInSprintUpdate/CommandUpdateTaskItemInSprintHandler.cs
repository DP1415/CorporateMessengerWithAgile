using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Persistence;
using Domain.ValueObjects;
using Application.AbsCommand.Update;
using Application.Dto.Summary;

namespace Application.Entity.TaskItemInSprints.Commands.TaskItemInSprintUpdate
{
    public class CommandUpdateTaskItemInSprintHandler(AppDbContext context, IMapper mapper)
        : AbsCommandUpdateEntityByIdHandler<CommandUpdateTaskItemInSprint, TaskItemInSprint, TaskItemInSprintSummaryDto>(context, mapper)
    {
        protected override Result<TaskItemInSprint> Update(TaskItemInSprint entity, CommandUpdateTaskItemInSprint request)
        {
            if (request.TaskStatus is not null)
                entity.TaskStatus = request.TaskStatus.Value;

            if (request.TaskItemId is not null)
                entity.TaskItemId = request.TaskItemId.Value;

            if (request.SprintId is not null)
                entity.SprintId = request.SprintId.Value;

            return entity;
        }
    }
}
