using Application.Dto;
using Application.Entity.Employees;
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
