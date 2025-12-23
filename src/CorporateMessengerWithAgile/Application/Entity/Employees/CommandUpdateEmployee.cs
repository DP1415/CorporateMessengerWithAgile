using Application.AbsCommand.Update;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Employees
{
    public record CommandUpdateEmployee
        (
            Guid Id,
            Guid? CompanyId,
            Guid? PositionInCompanyId,
            Guid? UserId
        )
        : AbsCommandUpdateEntityById<Employee, EmployeeDto>(Id);
}
