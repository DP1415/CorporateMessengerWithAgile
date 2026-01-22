using Application.AbsQuery;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.Employees.Queries.EmployeeGetProjectsAndTeams
{
    public class EmployeeGetProjectsAndTeamsQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityHandler<EmployeeGetProjectsAndTeamsQuery, TeamMember, ProjectWithTeams[]>(context, mapper)
    {
        public override async Task<ProjectWithTeams[]> Handle(
            EmployeeGetProjectsAndTeamsQuery request,
            CancellationToken cancellationToken)
        {
            TeamMember[] teamMembers = await _context.TeamMembers
                .AsNoTracking()
                .Where(tm => tm.EmployeeId == request.EmployeeId)
                .Include(tm => tm.Team)
                    .ThenInclude(t => t.Project)
                .ToArrayAsync(cancellationToken);

            if (teamMembers.Length == 0) return [];

            Dictionary<Guid, List<Team>> teamsByProject = teamMembers
                .GroupBy(tm => tm.Team.Project.Id)
                .ToDictionary(g => g.Key, g => g.Select(tm => tm.Team).ToList());

            ProjectWithTeams[] result = new ProjectWithTeams[teamsByProject.Count];

            int index = 0;
            foreach (KeyValuePair<Guid, List<Team>> group in teamsByProject)
                result[index++] = new(
                    _mapper.Map<ProjectDto>(group.Value[0].Project),
                    _mapper.Map<TeamDto[]>(group.Value)
                );

            return result;
        }
    }
}
