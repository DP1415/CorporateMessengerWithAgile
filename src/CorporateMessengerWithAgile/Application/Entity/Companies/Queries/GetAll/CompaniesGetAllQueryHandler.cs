using Application.AbsQuery;
using Domain.Entity;
using AutoMapper;
using Persistence;
using Application.Dto.Summary;

namespace Application.Entity.Companies.Queries.GetAll
{
    public class CompaniesGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityWithOptionsHandler<CompaniesGetAllQuery, Company, CompanySummaryDto>(context, mapper);
}
