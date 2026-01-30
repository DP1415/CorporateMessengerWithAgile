using Application.AbsCommand.Create;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Persistence;

namespace Application.Entity.Employees.Commands.EmployeeCreate
{
    public class CommandCreateEmployeeHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreateEmployee, Employee, EmployeeSummaryDto>(context, mapper)
    {
        public override Result<Employee> Create(CommandCreateEmployee request)
        {
            var employee = new Employee
            {
                CompanyId = request.CompanyId,
                PositionInCompanyId = request.PositionInCompanyId,
                UserId = request.UserId
            };

            return employee;
        }
    }
}
