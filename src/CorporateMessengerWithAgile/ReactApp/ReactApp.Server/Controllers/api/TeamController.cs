using Application.Dto.Summary;
using Application.Entity.Teams.Commands.TeamCreate;
using Application.Entity.Teams.Commands.TeamDelete;
using Application.Entity.Teams.Commands.TeamUpdate;
using Application.Entity.Teams.Queries.TeamsGetAll;
using Domain.Entity;
using MediatR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class TeamController(ISender sender) : ApiControllerBase
        <
            Team,
            TeamSummaryDto,
            TeamsGetAllQuery,
            CommandCreateTeam,
            CommandUpdateTeam,
            CommandDeleteTeam
        >(
            sender,
            id => new CommandDeleteTeam(id)
        );
}
