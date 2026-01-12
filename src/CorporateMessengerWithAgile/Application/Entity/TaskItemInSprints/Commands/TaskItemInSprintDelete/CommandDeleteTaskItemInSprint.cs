using Application.AbsCommand.Delete;
using Domain.Entity;

namespace Application.Entity.TaskItemInSprints.Commands.TaskItemInSprintDelete
{
    public record CommandDeleteTaskItemInSprint(Guid Id) : AbsCommandDeleteEntityById<TaskItemInSprint>(Id);
}
