using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;
using Application.Dto.Summary;

namespace Application.Entity.PositionInCompany_s.Queries.PositionInCompaniesGetAll
{
    public class PositionInCompaniesGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityWithOptionsHandler<PositionInCompaniesGetAllQuery, PositionInCompany, PositionInCompanySummaryDto>(context, mapper);
}
