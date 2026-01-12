using Application.AbsCommand.Delete;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Employees.Commands.EmployeeDelete
{
    public class CommandDeleteEmployeeHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteEmployee, Employee>(context);
}
