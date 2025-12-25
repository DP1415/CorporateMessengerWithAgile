using Application.Dto;
using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Projects
{
    public class ProjectsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityHandler<ProjectsGetAllQuery, Project, ProjectDto>(context, mapper);
}
