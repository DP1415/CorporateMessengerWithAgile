using Application.Entity.Projects.Queries.GetByCompanyId;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.reports
{
    [Tags(ReportsControllerBaseTag)]
    public class ProjectController(ISender sender) : ReportsControllerBase(sender)
    {
        [HttpGet]
        public async Task<Result<ProjectGetByCompanyIdDto>> GetAll(
            [FromHeader] Guid companyid,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(new ProjectGetByCompanyIdQuery(companyid), cancellationToken);
    }
}
