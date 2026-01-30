using Application.Dto;
using Application.AbsQuery;
using Domain.Entity;
using Domain.Result;

namespace Application.Entity.Teams.Queries.TeamGetByIdWithDetails
{
    public record TeamGetByIdWithDetailsQuery
        (
            Guid TeamId
        )
        : AbsQueryEntity<Team, Result<TeamWithRelationsDto>>;
}
