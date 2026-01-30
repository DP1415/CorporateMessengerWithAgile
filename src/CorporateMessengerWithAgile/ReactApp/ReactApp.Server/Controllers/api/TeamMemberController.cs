using Application.Dto.Summary;
using Application.Entity.TeamMembers.Commands.TeamMemberCreate;
using Application.Entity.TeamMembers.Commands.TeamMemberDelete;
using Application.Entity.TeamMembers.Commands.TeamMemberUpdate;
using Application.Entity.TeamMembers.Queries.TeamMembersGetAll;
using Domain.Entity;
using MediatR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class TeamMemberController(ISender sender) : ApiControllerBase
        <
            TeamMember,
            TeamMemberSummaryDto,
            TeamMembersGetAllQuery,
            CommandCreateTeamMember,
            CommandUpdateTeamMember,
            CommandDeleteTeamMember
        >(
            sender,
            id => new CommandDeleteTeamMember(id)
        );
}