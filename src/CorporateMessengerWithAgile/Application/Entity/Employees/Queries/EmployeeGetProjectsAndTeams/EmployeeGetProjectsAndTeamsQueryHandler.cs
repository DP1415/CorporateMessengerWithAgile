using Application.AbsQuery;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.Employees.Queries.EmployeeGetProjectsAndTeams
{
    public class EmployeeGetProjectsAndTeamsQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityHandler<EmployeeGetProjectsAndTeamsQuery, TeamMember, IEnumerable<ProjectWithTeams>>(context, mapper)
    {
        public override async Task<IEnumerable<ProjectWithTeams>> Handle(
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

            ProjectWithTeams[] result = [.. teamMembers
                .GroupBy(tm => tm.Team.Project)
                .Select(
                    group => new ProjectWithTeams(
                        _mapper.Map<ProjectSummaryDto>(group.Key),
                        _mapper.Map<TeamSummaryDto[]>(group.Select(tm => tm.Team))
                    )
                )];

            return result;
        }
    }
}
