using Application.AbsCommand.Create;
using Application.Dto.Summary;
using Domain.Entity;

namespace Application.Entity.TeamMembers.Commands.TeamMemberCreate
{
    public record CommandCreateTeamMember(
        Guid EmployeeId,
        Guid TeamId
    ) : AbsCommandCreateEntity<TeamMember, TeamMemberSummaryDto>;
}
