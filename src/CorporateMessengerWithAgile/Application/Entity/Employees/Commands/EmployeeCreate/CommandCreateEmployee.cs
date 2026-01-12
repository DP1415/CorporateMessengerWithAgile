using Application.AbsCommand.Create;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Employees.Commands.EmployeeCreate
{
    public record CommandCreateEmployee
        (
            Guid CompanyId,
            Guid PositionInCompanyId,
            Guid UserId
        )
        : AbsCommandCreateEntity<Employee, EmployeeDto>;
}
