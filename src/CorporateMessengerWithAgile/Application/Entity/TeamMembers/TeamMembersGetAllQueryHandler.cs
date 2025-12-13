using Application.Dto;
using Application.Query;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.TeamMembers
{
    public class TeamMembersGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<TeamMembersGetAllQuery, TeamMember, TeamMemberDto>(context, mapper);
}
