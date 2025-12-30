using Application.AbsQuery;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.Projects.Queries.GetByCompanyId
{
    public class ProjectGetByCompanyIdQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityHandler<ProjectGetByCompanyIdQuery, Project, Result<ProjectGetByCompanyIdDto>>(context, mapper)
    {
        public override async Task<Result<ProjectGetByCompanyIdDto>> Handle(
            ProjectGetByCompanyIdQuery request,
            CancellationToken cancellationToken)
        {
            var projects = await _dbSet
                .Where(p => p.CompanyId == request.CompanyId)
                .Include(p => p.TaskItems)
                .Include(p => p.Teams)
                .ToListAsync(cancellationToken);

            if (projects.Count == 0)
            {
                return new ProjectGetByCompanyIdDto([], [], []);
            }

            var allTaskItems = projects.SelectMany(p => p.TaskItems).ToList();
            var allTeams = projects.SelectMany(p => p.Teams).ToList();

            return new ProjectGetByCompanyIdDto(
                Projects: _mapper.Map<List<ProjectDto>>(projects),
                TaskItems: _mapper.Map<List<TaskItemDto>>(allTaskItems),
                Teams: _mapper.Map<List<TeamDto>>(allTeams)
            );
        }
    }
}