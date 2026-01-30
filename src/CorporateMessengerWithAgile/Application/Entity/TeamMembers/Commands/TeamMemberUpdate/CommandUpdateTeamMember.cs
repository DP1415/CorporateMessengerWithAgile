using Application.AbsCommand.Update;
using Application.Dto.Summary;
using Domain.Entity;

namespace Application.Entity.TeamMembers.Commands.TeamMemberUpdate
{
    public record CommandUpdateTeamMember(
        Guid Id,
        Guid? EmployeeId,
        Guid? TeamId
    ) : AbsCommandUpdateEntityById<TeamMember, TeamMemberSummaryDto>(Id);
}
