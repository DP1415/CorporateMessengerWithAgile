using Application.AbsQuery;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.Employees.Queries.EmployeeGetByUserId
{
    public class EmployeeGetByUserIdQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityHandler<EmployeeGetByUserIdQuery, TeamMember, IEnumerable<EmployeeWithRelations>>(context, mapper)
    {
        public override async Task<IEnumerable<EmployeeWithRelations>> Handle(EmployeeGetByUserIdQuery request, CancellationToken cancellationToken)
        {
            Employee[] employees = await _context.Employees
                .AsNoTracking()
                .Where(e => e.UserId == request.UserId)
                .Include(e => e.Company)
                .Include(e => e.PositionInCompany)
                .Include(e => e.TeamMembers)
                    .ThenInclude(tm => tm.Team)
                        .ThenInclude(t => t.Project)
                .ToArrayAsync(cancellationToken);

            if (employees.Length == 0) return [];

            var result =
                from employee in employees
                select new EmployeeWithRelations(
                    EmployeeId: employee.Id,
                    Company: _mapper.Map<CompanySummaryDto>(employee.Company),
                    PositionInCompany: _mapper.Map<PositionInCompanySummaryDto>(employee.PositionInCompany),
                    ProjectsAndTeams: from teamMember in employee.TeamMembers
                                      where teamMember.Team != null && teamMember.Team.Project != null
                                      group teamMember by teamMember.Team.Project.Id into teamMemberGroup
                                      let project = teamMemberGroup.First().Team.Project
                                      orderby project.Title.Value
                                      select new ProjectWithTeams(
                                          Project: _mapper.Map<ProjectSummaryDto>(project),
                                          Teams: _mapper.Map<TeamSummaryDto[]>(from teamMember in teamMemberGroup
                                                                               orderby teamMember.Team.Title.Value
                                                                               select teamMember.Team
                                                                               )));
            return result;
        }
    }
}
