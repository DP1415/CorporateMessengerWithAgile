using Application.Dto;
using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;

namespace Application.Entity.PositionInCompany_s
{
    public record PositionInCompaniesGetAllQuery()
        : AbsQueryEntityWithOptions<PositionInCompany, PositionInCompanyDto>(
            [
                new Include<PositionInCompany, Company>(p => p.Company),
                new Include<PositionInCompany, ICollection<Employee>>(p => p.Employees)
            ]
        );
}
