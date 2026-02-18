using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;
using Application.Dto.Summary;

namespace Application.Entity.PositionInCompany_s.Queries.PositionInCompaniesGetAll
{
    public record PositionInCompaniesGetAllQuery()
        : AbsQueryEntityWithOptions<PositionInCompany, PositionInCompanySummaryDto>(
            [
                new Include<PositionInCompany, Company>(p => p.Company),
                new Include<PositionInCompany, ICollection<Employee>>(p => p.Employees)
            ]
        );
}
