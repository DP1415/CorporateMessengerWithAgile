using Application.AbsCommand.Create;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Persistence;

namespace Application.Entity.TeamMembers.Commands.TeamMemberCreate
{
    public class CommandCreateTeamMemberHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreateTeamMember, TeamMember, TeamMemberDto>(context, mapper)
    {
        public override Result<TeamMember> Create(CommandCreateTeamMember request)
        {
            var teamMember = new TeamMember
            {
                EmployeeId = request.EmployeeId,
                TeamId = request.TeamId
            };

            return teamMember;
        }
    }
}
