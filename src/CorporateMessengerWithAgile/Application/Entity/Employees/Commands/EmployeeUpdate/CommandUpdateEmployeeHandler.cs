using Application.AbsCommand.Update;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Persistence;

namespace Application.Entity.Employees.Commands.EmployeeUpdate
{
    public class CommandUpdateEmployeeHandler(AppDbContext context, IMapper mapper)
        : AbsCommandUpdateEntityByIdHandler<CommandUpdateEmployee, Employee, EmployeeDto>(context, mapper)
    {
        protected override Result<Employee> Update(Employee entity, CommandUpdateEmployee request)
        {
            if (request.CompanyId.HasValue)
            {
                entity.CompanyId = request.CompanyId.Value;
            }

            if (request.PositionInCompanyId.HasValue)
            {
                entity.PositionInCompanyId = request.PositionInCompanyId.Value;
            }

            if (request.UserId.HasValue)
            {
                entity.UserId = request.UserId.Value;
            }

            return entity;
        }
    }
}
