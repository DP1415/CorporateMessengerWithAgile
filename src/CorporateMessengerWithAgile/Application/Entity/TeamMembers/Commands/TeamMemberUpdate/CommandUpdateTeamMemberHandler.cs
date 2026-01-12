using Application.AbsCommand.Update;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Persistence;

namespace Application.Entity.TeamMembers.Commands.TeamMemberUpdate
{
    public class CommandUpdateTeamMemberHandler(AppDbContext context, IMapper mapper)
        : AbsCommandUpdateEntityByIdHandler<CommandUpdateTeamMember, TeamMember, TeamMemberDto>(context, mapper)
    {
        protected override Result<TeamMember> Update(TeamMember entity, CommandUpdateTeamMember request)
        {
            if (request.EmployeeId.HasValue)
                entity.EmployeeId = request.EmployeeId.Value;

            if (request.TeamId.HasValue)
                entity.TeamId = request.TeamId.Value;

            return entity;
        }
    }
}
