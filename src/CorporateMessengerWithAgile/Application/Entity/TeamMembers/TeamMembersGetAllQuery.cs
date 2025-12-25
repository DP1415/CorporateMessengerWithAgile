using Application.Dto;
using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;

namespace Application.Entity.TeamMembers
{
    public record TeamMembersGetAllQuery()
        : AbsQuery<TeamMember, TeamMemberDto>(
            [
                new Include<TeamMember, Employee>(tm => tm.Employee),
                new Include<TeamMember, Team>(tm => tm.Team)
            ]
        );
}
