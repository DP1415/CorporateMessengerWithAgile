using Application.Dto;
using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Projects.Queries.GetAll
{
    public class ProjectsGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityWithOptionsHandler<ProjectsGetAllQuery, Project, ProjectDto>(context, mapper);
}
