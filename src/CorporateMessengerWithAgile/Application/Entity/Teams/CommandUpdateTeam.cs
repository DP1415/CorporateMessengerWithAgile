using Application.AbsCommand.Update;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Teams
{
    public record CommandUpdateTeam(
        Guid Id,
        string? Title,
        int? StandardSprintDuration,
        Guid? ProjectId
    ) : AbsCommandUpdateEntityById<Team, TeamDto>(Id);
}
