using Application.Dto;
using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Teams.Queries.TeamsGetAll
{
    public class TeamsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryGetAllEntityHandler<TeamsGetAllQuery, Team, TeamDto>(context, mapper);
}
