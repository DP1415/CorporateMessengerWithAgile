using Application.Dto;
using Application.Query.Options;
using Application.Query;
using Domain.Entity;

namespace Application.Entity.Sprints
{
    public record SprintsGetAllQuery()
        : AbsQuery<Sprint, SprintDto>(
            [
                new Include<Sprint, Team>(s => s.Team),
                new Include<Sprint, ICollection<TaskItem>>(s => s.TaskItems),
                new Include<Sprint, ICollection<TaskItemInSprint>>(s => s.TaskItemInSprints)
            ]
        );
}
