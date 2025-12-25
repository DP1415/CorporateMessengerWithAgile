using Application.Dto;
using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.PositionInCompany_s
{
    public class PositionInCompaniesGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityHandler<PositionInCompaniesGetAllQuery, PositionInCompany, PositionInCompanyDto>(context, mapper);
}
