using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;
using Application.Dto.Summary;

namespace Application.Entity.TeamMembers.Queries.TeamMembersGetAll
{
    public record TeamMembersGetAllQuery()
        : AbsQueryEntityWithOptions<TeamMember, TeamMemberSummaryDto>(
            [
                new Include<TeamMember, Employee>(tm => tm.Employee),
                new Include<TeamMember, Team>(tm => tm.Team)
            ]
        );
}
