using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;
using Application.Dto.Summary;

namespace Application.Entity.Sprints.Queries.SprintsGetAll
{
    public record SprintsGetAllQuery()
        : AbsQueryEntityWithOptions<Sprint, SprintSummaryDto>(
            [
                new Include<Sprint, Team>(s => s.Team),
                new Include<Sprint, ICollection<TaskItem>>(s => s.TaskItems),
                new Include<Sprint, ICollection<TaskItemInSprint>>(s => s.TaskItemInSprints)
            ]
        );
}
