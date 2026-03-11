using Application.Entity.Employees.Queries.EmployeeGetByUserId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers
{
    [Route("cmwa/[controller]")]
    public class EmployeeController(ISender sender) : AuthorizedBaseController(sender)
    {
        [HttpGet("employees")]
        public Task<IEnumerable<EmployeeWithRelations>> GetEmployeesByUserId(CancellationToken cancellationToken)
            => SendAuth<EmployeeGetByUserIdQuery, IEnumerable<EmployeeWithRelations>>(new EmployeeGetByUserIdQuery(), cancellationToken);
    }
}
