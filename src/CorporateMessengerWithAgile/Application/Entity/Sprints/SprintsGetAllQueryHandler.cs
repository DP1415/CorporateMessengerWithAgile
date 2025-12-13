using Application.Dto;
using Application.Query;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Sprints
{
    public class SprintsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<SprintsGetAllQuery, Sprint, SprintDto>(context, mapper);
}
