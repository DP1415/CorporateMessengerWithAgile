using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;
using Application.Dto.Summary;

namespace Application.Entity.Teams.Queries.TeamsGetAll
{
    public class TeamsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityWithOptionsHandler<TeamsGetAllQuery, Team, TeamSummaryDto>(context, mapper);
}
