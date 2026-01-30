using Application.AbsQuery;
using Application.AbsQuery.Options;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Employees.Queries.EmployeeGetByUsername
{
    public record EmployeeGetByUsernameQuery(string Username)
        : AbsQueryEntityWithOptions<Employee, EmployeeWithRelationsDto>(
            [
                new Filter<Employee>(e => e.User != null && e.User.Username.Value == Username),
                new Include<Employee, Company>(e => e.Company),
                new Include<Employee, PositionInCompany>(e => e.PositionInCompany),
                new Include<Employee, User>(e => e.User),
                new Include<Employee, ICollection<TeamMember>>(e => e.TeamMembers)
            ]
        );
}
