using Application.Dto;
using Application.Entity.Companies.Queries.GetAll;
using Application.Entity.Projects.Queries.GetByCompanyId;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.reports
{
    [ApiController]
    //[Route("cmwa/reports/Company/{companyid:guid}/Project")]
    [Route("cmwa/reports/[controller]")]
    [Tags("CMWA / Reports")]
    public class ProjectController(ISender sender) : ApiController(sender)
    {
        [HttpGet]
        public async Task<Result<ProjectGetByCompanyIdDto>> GetAll(
            [FromHeader] Guid companyid,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new ProjectGetByCompanyIdQuery(companyid), cancellationToken);
    }
}
