using Application.AbsQuery;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.Employees.Queries.EmployeeGetProjectsAndTeams
{
    public class EmployeeGetProjectsAndTeamsQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityHandler<EmployeeGetProjectsAndTeamsQuery, TeamMember, EmployeeProjectsAndTeamsDto>(context, mapper)
    {
        public override async Task<EmployeeProjectsAndTeamsDto> Handle(
            EmployeeGetProjectsAndTeamsQuery request,
            CancellationToken cancellationToken)
        {
            TeamMember[] teamMembers = await _context.TeamMembers
                .AsNoTracking()
                .Where(tm => tm.EmployeeId == request.EmployeeId)
                .Include(tm => tm.Team)
                    .ThenInclude(t => t.Project)
                .ToArrayAsync(cancellationToken);

            Team[] teams = [.. teamMembers.Select(tm => tm.Team)];

            Project[] projects = [.. teams.Select(t => t.Project)];

            return new EmployeeProjectsAndTeamsDto
            {
                Teams = _mapper.Map<List<TeamDto>>(teams),
                Projects = _mapper.Map<List<ProjectDto>>(projects)
            };
        }
    }
}