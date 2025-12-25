using Application.Dto;
using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.TeamMembers
{
    public class TeamMembersGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryGetAllEntityHandler<TeamMembersGetAllQuery, TeamMember, TeamMemberDto>(context, mapper);
}
