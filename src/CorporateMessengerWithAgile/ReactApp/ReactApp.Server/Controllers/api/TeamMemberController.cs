using Application.Dto;
using Application.Entity.TeamMembers;
using Domain.Entity;
using MediatR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class TeamMemberController(ISender sender) : ApiControllerBase
        <
            TeamMember,
            TeamMemberDto,
            TeamMembersGetAllQuery,
            CommandCreateTeamMember,
            CommandUpdateTeamMember,
            CommandDeleteTeamMember
        >(
            sender,
            id => new CommandDeleteTeamMember(id)
        );
}