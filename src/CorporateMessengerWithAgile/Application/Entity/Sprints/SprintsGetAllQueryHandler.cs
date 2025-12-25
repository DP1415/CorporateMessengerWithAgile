using Application.Dto;
using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Sprints
{
    public class SprintsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityHandler<SprintsGetAllQuery, Sprint, SprintDto>(context, mapper);
}
