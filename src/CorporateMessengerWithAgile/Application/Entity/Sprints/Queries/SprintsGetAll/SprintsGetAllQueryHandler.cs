using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;
using Application.Dto.Summary;

namespace Application.Entity.Sprints.Queries.SprintsGetAll
{
    public class SprintsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityWithOptionsHandler<SprintsGetAllQuery, Sprint, SprintSummaryDto>(context, mapper);
}
