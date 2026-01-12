using Application.Dto;
using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Sprints.Queries.SprintsGetAll
{
    public class SprintsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityWithOptionsHandler<SprintsGetAllQuery, Sprint, SprintDto>(context, mapper);
}
