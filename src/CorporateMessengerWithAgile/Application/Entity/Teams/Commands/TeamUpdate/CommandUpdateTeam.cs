using Application.AbsCommand.Update;
using Application.Dto.Summary;
using Domain.Entity;

namespace Application.Entity.Teams.Commands.TeamUpdate
{
    public record CommandUpdateTeam(
        Guid Id,
        string? Title,
        int? StandardSprintDuration,
        Guid? ProjectId
    ) : AbsCommandUpdateEntityById<Team, TeamSummaryDto>(Id);
}
