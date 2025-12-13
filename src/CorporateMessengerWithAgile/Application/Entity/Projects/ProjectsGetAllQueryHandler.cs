using Application.Dto;
using Application.Query;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Projects
{
    public class ProjectsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<ProjectsGetAllQuery, Project, ProjectDto>(context, mapper);
}
