using Application.Dto;
using Application.Entity.Employees;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Abstract;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController(ISender sender) : ApiController(sender)
    {
        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> GetAll(
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new EmployeesGetAllQuery(), cancellationToken);

        [HttpPost]
        public async Task<Result<EmployeeDto>> Create(
            [FromBody] CommandCreateEmployee command,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(command, cancellationToken);

        [HttpDelete("{id}")]
        public async Task<Result> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new CommandDeleteEmployee(id), cancellationToken);

        [HttpPut]
        public async Task<Result<EmployeeDto>> Change(
            [FromBody] CommandUpdateEmployee command,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(command, cancellationToken);
    }
}
