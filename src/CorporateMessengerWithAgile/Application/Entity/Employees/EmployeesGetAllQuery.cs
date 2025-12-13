using Application.Dto;
using Application.Query.Options;
using Application.Query;
using Domain.Entity;

namespace Application.Entity.Employees
{
    public record EmployeesGetAllQuery() : AbsQuery<Employee, EmployeeDto>
        (
            [
                new Include<Employee, Company>(e => e.Company),
                new Include<Employee, PositionInCompany>(e => e.PositionInCompany),
                new Include<Employee, User>(e => e.User),
                new Include<Employee, ICollection<TeamMember>>(e => e.TeamMembers)
            ]
        );
}
