using Application.Dto;
using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;

namespace Application.Entity.Projects
{
    public record ProjectsGetAllQuery()
        : AbsQueryGetAllEntity<Project, ProjectDto>(
            [
                new Include<Project, Company>(p => p.Company),
                new Include<Project, ICollection<TaskItem>>(p => p.TaskItems),
                new Include<Project, ICollection<Team>>(p => p.Teams)
            ]
        );
}
