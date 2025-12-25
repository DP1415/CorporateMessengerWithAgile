using Application.Dto;
using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;

namespace Application.Entity.Sprints
{
    public record SprintsGetAllQuery()
        : AbsQueryGetAllEntity<Sprint, SprintDto>(
            [
                new Include<Sprint, Team>(s => s.Team),
                new Include<Sprint, ICollection<TaskItem>>(s => s.TaskItems),
                new Include<Sprint, ICollection<TaskItemInSprint>>(s => s.TaskItemInSprints)
            ]
        );
}
