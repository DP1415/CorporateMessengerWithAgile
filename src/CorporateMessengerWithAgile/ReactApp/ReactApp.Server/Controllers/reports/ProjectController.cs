using Application.Entity.Projects.Queries.GetByCompanyId;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.reports
{
    [Tags(ReportsControllerBaseTag)]
    public class ProjectController(ISender sender) : ReportsControllerBase(sender)
    {
        [HttpGet]
        public async Task<ActionResult<ProjectGetByCompanyIdQueryOutput>> GetAll(
            [FromHeader] Guid companyid,
            CancellationToken cancellationToken = default
        ) => (await Sender.Send(new ProjectGetByCompanyIdQuery(companyid), cancellationToken)).ToActionResult();
    }
}
