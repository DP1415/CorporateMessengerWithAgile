using Application.Dto;
using Application.Query.Options;
using Application.Query;
using Domain.Entity;

namespace Application.Entity.Projects
{
    public record ProjectsGetAllQuery()
        : AbsQuery<Project, ProjectDto>(
            [
                new Include<Project, Company>(p => p.Company),
                new Include<Project, ICollection<TaskItem>>(p => p.TaskItems),
                new Include<Project, ICollection<Team>>(p => p.Teams)
            ]
        );
}
