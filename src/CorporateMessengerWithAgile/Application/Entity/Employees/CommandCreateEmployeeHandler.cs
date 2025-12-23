using Application.AbsCommand.Create;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Persistence;

namespace Application.Entity.Employees
{
    public class CommandCreateEmployeeHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreateEmployee, Employee, EmployeeDto>(context, mapper)
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
