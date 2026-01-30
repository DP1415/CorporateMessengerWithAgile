using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;
using Application.Dto.Summary;

namespace Application.Entity.Companies.Queries.GetAll
{
    public record CompaniesGetAllQuery() : AbsQueryEntityWithOptions<Company, CompanySummaryDto>
    (
        [
            new Include<Company, ICollection<Employee>>(company => company.Employees),
            new Include<Company, ICollection<PositionInCompany>>(company => company.Positions),
            new Include<Company, ICollection<Project>>(company => company.Projects)
        ]
    );
}
