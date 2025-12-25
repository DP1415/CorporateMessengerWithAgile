using Application.Dto;
using Application.AbsQuery;
using Domain.Entity;
using AutoMapper;
using Persistence;

namespace Application.Entity.Companies
{
    public class CompaniesGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<CompaniesGetAllQuery, Company, CompanyDto>(context, mapper);
}
