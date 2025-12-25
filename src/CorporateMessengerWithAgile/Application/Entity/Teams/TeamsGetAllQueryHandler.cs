using Application.Dto;
using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Teams
{
    public class TeamsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityHandler<TeamsGetAllQuery, Team, TeamDto>(context, mapper);
}
