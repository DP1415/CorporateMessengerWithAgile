using Application.AbsQuery;
using Domain.Entity;
using Application.Dto.Summary;

namespace Application.Entity.Sprints.Queries.SprintsGetByTeam
{
    public record SprintsGetByTeamQuery
        (
            Guid TeamId
        )
        : AbsQueryEntity<Sprint, IEnumerable<SprintSummaryDto>>;
}
