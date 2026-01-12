using Application.Dto;
using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;

namespace Application.Entity.Teams.Queries.TeamsGetAll
{
    public record TeamsGetAllQuery()
        : AbsQueryGetAllEntity<Team, TeamDto>(
            [
                new Include<Team, Project>(t => t.Project),
                new Include<Team, ICollection<TeamMember>>(t => t.TeamMembers),
                new Include<Team, ICollection<Sprint>>(t => t.Sprints),
                new Include<Team, ICollection<KanbanBoardColumn>>(t => t.KanbanBoardColumns)
            ]
        );
}
