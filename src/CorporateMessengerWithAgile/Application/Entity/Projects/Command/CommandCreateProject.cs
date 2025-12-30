using Application.AbsCommand.Create;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Projects.Command
{
    public record CommandCreateProject(
        string Title,
        Guid CompanyId
    ) : AbsCommandCreateEntity<Project, ProjectDto>;
}
