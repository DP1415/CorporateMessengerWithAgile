using Application.Dto;
using Application.Entity.Teams;
using Domain.Entity;
using MediatR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class TeamController(ISender sender) : ApiControllerBase
        <
            Team,
            TeamDto,
            TeamsGetAllQuery,
            CommandCreateTeam,
            CommandUpdateTeam,
            CommandDeleteTeam
        >(
            sender,
            id => new CommandDeleteTeam(id)
        );
}
