using Application.AbsCommand.Create;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Projects.Command.ProjectCreate
{
    public record CommandCreateProject(
        string Title,
        Guid CompanyId
    ) : AbsCommandCreateEntity<Project, ProjectDto>;
}
