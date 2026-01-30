using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;
using Application.Dto.Summary;

namespace Application.Entity.Projects.Queries.GetAll
{
    public class ProjectsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityWithOptionsHandler<ProjectsGetAllQuery, Project, ProjectSummaryDto>(context, mapper);
}
