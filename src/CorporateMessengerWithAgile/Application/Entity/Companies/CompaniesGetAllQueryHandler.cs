using Application.Dto;
using Application.AbsQuery;
using Domain.Entity;
using AutoMapper;
using Persistence;

namespace Application.Entity.Companies
{
    public class CompaniesGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityHandler<CompaniesGetAllQuery, Company, CompanyDto>(context, mapper);
}
