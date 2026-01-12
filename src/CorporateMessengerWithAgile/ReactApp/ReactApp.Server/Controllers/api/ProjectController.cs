using Application.Dto;
using Application.Entity.Projects.Command.ProjectCreate;
using Application.Entity.Projects.Command.ProjectDelete;
using Application.Entity.Projects.Command.ProjectUpdate;
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
