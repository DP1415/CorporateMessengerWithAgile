using Application.Dto;
using Application.AbsQuery;
using Domain.Entity;
using AutoMapper;
using Persistence;

namespace Application.Entity.Companies.Queries.GetAll
{
    public class CompaniesGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityWithOptionsHandler<CompaniesGetAllQuery, Company, CompanyDto>(context, mapper);
}
