using Application.AbsQuery;
using Application.Dto;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.Teams.Queries.TeamGetByIdWithDetails
{
    public class TeamGetByIdWithDetailsQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityHandler<TeamGetByIdWithDetailsQuery, Team, Result<TeamWithRelationsDto>>(context, mapper)
    {
        public override async Task<Result<TeamWithRelationsDto>> Handle(TeamGetByIdWithDetailsQuery request, CancellationToken cancellationToken)
        {
            Team? team = await _dbSet
                .Include(t => t.Project)
                .Include(t => t.TeamMembers).ThenInclude(tm => tm.Employee).ThenInclude(e => e.User)
                .Include(t => t.Sprints)
                .Include(t => t.KanbanBoardColumns)
                .FirstOrDefaultAsync(t => t.Id == request.TeamId, cancellationToken);

            if (team is null) return ApplicationErrors.TeamError.NotFound(request.TeamId);

            List<Employee> employees = [.. team.TeamMembers.Select(tm => tm.Employee)];

            List<Sprint> sprints = [.. team.Sprints];

            List<KanbanBoardColumn> kanbanBoardColumns = [.. team.KanbanBoardColumns];

            TeamWithRelationsDto teamWithRelationsDto = new()
            {
                Id = team.Id,
                ProjectId = team.ProjectId,
                Title = team.Title.Value,
                StandardSprintDuration = team.StandardSprintDuration,
                Users = _mapper.Map<IReadOnlyList<EmployeeSummaryDto>>(employees),
                Sprints = _mapper.Map<IReadOnlyList<SprintSummaryDto>>(sprints),
                KanbanBoardColumnIds = _mapper.Map<List<KanbanBoardColumnSummaryDto>>(kanbanBoardColumns)
            };

            return teamWithRelationsDto;
        }
    }
}
