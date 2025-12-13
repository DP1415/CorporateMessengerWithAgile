using Application.Command;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.TeamMembers
{
    public record CommandCreateTeamMember(
        Guid EmployeeId,
        Guid TeamId
    ) : AbsCommandCreateEntity<TeamMember, TeamMemberDto>;
}
