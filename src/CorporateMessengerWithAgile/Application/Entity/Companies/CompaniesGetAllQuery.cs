using Application.Dto;
using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;

namespace Application.Entity.Companies
{
    public record CompaniesGetAllQuery() : AbsQuery<Company, CompanyDto>
    (
        [
            new Include<Company, ICollection<Employee>>(company => company.Employees),
            new Include<Company, ICollection<PositionInCompany>>(company => company.Positions),
            new Include<Company, ICollection<Project>>(company => company.Projects)
        ]
    );
}
