using Application.AbsQuery;
using Domain.Entity;
using Domain.Result;

namespace Application.Entity.Projects.Queries.GetByCompanyId
{
    public record class ProjectGetByCompanyIdQuery
        (
            Guid CompanyId
        )
        : AbsQueryEntity<Project, Result<ProjectGetByCompanyIdDto>>;
}