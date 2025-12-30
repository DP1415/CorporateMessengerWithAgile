using Application.Dto;
using Application.Entity.Projects.Command;
using Application.Entity.Projects.Queries.GetAll;
using Domain.Entity;
using MediatR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class ProjectController(ISender sender) : ApiControllerBase
        <
            Project,
            ProjectDto,
            ProjectsGetAllQuery,
            CommandCreateProject,
            CommandUpdateProject,
            CommandDeleteProject
        >(
            sender,
            id => new CommandDeleteProject(id)
        );
}
