using Application.AbsCommand.Delete;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Employees
{
    public class CommandDeleteEmployeeHandler(AppDbContext context)
        : AbsCommandDeleteEntityByIdHandler<CommandDeleteEmployee, Employee>(context);
}
