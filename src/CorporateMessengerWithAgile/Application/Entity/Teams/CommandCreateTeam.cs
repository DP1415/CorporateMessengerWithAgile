using Application.AbsCommand.Create;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Teams
{
    public record CommandCreateTeam(
        string Title,
        int StandardSprintDuration,
        Guid ProjectId
    ) : AbsCommandCreateEntity<Team, TeamDto>;
}
