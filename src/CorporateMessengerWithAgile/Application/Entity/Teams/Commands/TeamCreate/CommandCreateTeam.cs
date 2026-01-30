using Application.AbsCommand.Create;
using Application.Dto.Summary;
using Domain.Entity;

namespace Application.Entity.Teams.Commands.TeamCreate
{
    public record CommandCreateTeam(
        string Title,
        int StandardSprintDuration,
        Guid ProjectId
    ) : AbsCommandCreateEntity<Team, TeamSummaryDto>;
}
