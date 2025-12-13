using Application.Dto;
using Application.Query.Options;
using Application.Query;
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
