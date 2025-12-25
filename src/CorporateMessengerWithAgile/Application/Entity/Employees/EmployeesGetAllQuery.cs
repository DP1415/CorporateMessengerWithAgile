using Application.Dto;
using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;

namespace Application.Entity.Employees
{
    public record EmployeesGetAllQuery() : AbsQueryGetAllEntity<Employee, EmployeeDto>
        (
            [
                new Include<Employee, Company>(e => e.Company),
                new Include<Employee, PositionInCompany>(e => e.PositionInCompany),
                new Include<Employee, User>(e => e.User),
                new Include<Employee, ICollection<TeamMember>>(e => e.TeamMembers)
            ]
        );
}
