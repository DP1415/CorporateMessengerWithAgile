using Application.Dto;
using Application.Entity.Employees.Commands.EmployeeCreate;
using Application.Entity.Employees.Commands.EmployeeDelete;
using Application.Entity.Employees.Commands.EmployeeUpdate;
using Application.Entity.Employees.Queries.EmployeesGetAll;
using Domain.Entity;
using MediatR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class EmployeeController(ISender sender) : ApiControllerBase
        <
            Employee,
            EmployeeDto,
            EmployeesGetAllQuery,
            CommandCreateEmployee,
            CommandUpdateEmployee,
            CommandDeleteEmployee
        >(
            sender,
            id => new CommandDeleteEmployee(id)
        );
}
