using Application.AbsCommand.Update;
using Application.Dto.Summary;
using Domain.Entity;

namespace Application.Entity.Employees.Commands.EmployeeUpdate
{
    public record CommandUpdateEmployee
        (
            Guid Id,
            Guid? CompanyId,
            Guid? PositionInCompanyId,
            Guid? UserId
        )
        : AbsCommandUpdateEntityById<Employee, EmployeeSummaryDto>(Id);
}
