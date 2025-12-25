using Application.Dto;
using Application.Entity.Projects;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [ApiController]
    [Route("cmwa/api/[controller]")]
    [Tags("CMWA / API")]
    public class ProjectController(ISender sender) : ApiController(sender)
    {
        [HttpGet]
        public async Task<IEnumerable<ProjectDto>> GetAll(
            CancellationToken cancellationToken = default) =>
            await Sender.Send(new ProjectsGetAllQuery(), cancellationToken);

        [HttpPost]
        public async Task<Result<ProjectDto>> Create(
            [FromBody] CommandCreateProject command,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(command, cancellationToken);

        [HttpDelete("{id}")]
        public async Task<Result> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(new CommandDeleteProject(id), cancellationToken);

        [HttpPut]
        public async Task<Result<ProjectDto>> Change(
            [FromBody] CommandUpdateProject command,
            CancellationToken cancellationToken = default) =>
            await Sender.Send(command, cancellationToken);
    }
}
