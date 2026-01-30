using Application.AbsQuery.Options;
using Application.AbsQuery;
using Domain.Entity;
using Application.Dto.Summary;

namespace Application.Entity.Projects.Queries.GetAll
{
    public record ProjectsGetAllQuery()
        : AbsQueryEntityWithOptions<Project, ProjectSummaryDto>(
            [
                new Include<Project, Company>(p => p.Company),
                new Include<Project, ICollection<TaskItem>>(p => p.TaskItems),
                new Include<Project, ICollection<Team>>(p => p.Teams)
            ]
        );
}
