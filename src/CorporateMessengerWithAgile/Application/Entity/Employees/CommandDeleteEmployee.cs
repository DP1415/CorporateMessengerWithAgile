using Application.AbsCommand.Delete;
using Domain.Entity;

namespace Application.Entity.Employees
{
    public record CommandDeleteEmployee(Guid Id) : AbsCommandDeleteEntityById<Employee>(Id);
}
