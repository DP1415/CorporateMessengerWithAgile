using Application.Dto;
using Application.Query;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Teams
{
    public class TeamsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<TeamsGetAllQuery, Team, TeamDto>(context, mapper);
}
