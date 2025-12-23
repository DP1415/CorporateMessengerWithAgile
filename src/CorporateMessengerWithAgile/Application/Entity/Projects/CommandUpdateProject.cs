using Application.AbsCommand.Update;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Projects
{
    public record CommandUpdateProject(
        Guid Id,
        string? Title,
        Guid? CompanyId
    ) : AbsCommandUpdateEntityById<Project, ProjectDto>(Id);
}
