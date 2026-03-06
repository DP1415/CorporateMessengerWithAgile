using Application.AbsQuery;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.Sprints.Queries.SprintsGetByTeam
{
    public class SprintsGetByTeamQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<SprintsGetByTeamQuery, Sprint, IEnumerable<SprintSummaryDto>>(context, mapper)
    {
        public override async Task<IEnumerable<SprintSummaryDto>> Handle(
            SprintsGetByTeamQuery request,
            CancellationToken cancellationToken)
        {
            Sprint[] sprints = await _context.Sprints
                .AsNoTracking()
                .Where(s => s.TeamId == request.TeamId)
                .Join(_context.TeamMembers
                    .Where(tm => tm.Employee.User.Id == request.CurrentUserId)
                    .Select(tm => tm.TeamId),
                    s => s.TeamId,
                    teamId => teamId,
                    (s, _) => s)
                .OrderBy(s => s.DateStart)
                .Include(s => s.Team)
                .Include(s => s.TaskItems)
                .Include(s => s.TaskItemInSprints)
                .ToArrayAsync(cancellationToken);

            if (sprints.Length == 0) return [];

            return _mapper.Map<SprintSummaryDto[]>(sprints);
        }
    }
}
