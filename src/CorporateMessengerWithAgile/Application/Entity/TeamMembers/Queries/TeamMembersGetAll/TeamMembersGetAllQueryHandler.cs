using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;
using Application.Dto.Summary;

namespace Application.Entity.TeamMembers.Queries.TeamMembersGetAll
{
    public class TeamMembersGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityWithOptionsHandler<TeamMembersGetAllQuery, TeamMember, TeamMemberSummaryDto>(context, mapper);
}
