using Application.Dto;
using Application.Entity.Employees.Queries.EmployeeGetByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers
{
    [Route("cmwa/[controller]")]
    public class UserController(ISender sender) : AbstractController(sender)
    {
        [Authorize]
        [HttpGet("{id}/employees")]
        public async Task<IEnumerable<EmployeeWithCompanyAndPositionDto>> GetEmployeesByUserId(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new EmployeeGetByUserIdQuery(id), cancellationToken);
    }
}
