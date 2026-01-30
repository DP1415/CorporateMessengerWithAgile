using Application.AbsQuery;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.Companies.Queries.GetById
{
    public class CompanyGetByIdQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityHandler<CompanyGetByIdQuery, Company, Result<CompanyGetByIdDto>>(context, mapper)
    {
        public override async Task<Result<CompanyGetByIdDto>> Handle(CompanyGetByIdQuery request, CancellationToken cancellationToken)
        {
            Company? company = await _dbSet
                .Include(c => c.Projects)
                .Include(c => c.Employees).ThenInclude(e => e.User)
                .Include(c => c.Positions)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            IEnumerable<User> users = company?.Employees.Where(e => e.User != null).Select(e => e.User) ?? [];

            return
                company is null
                ? ApplicationErrors.CompanyError.NotFound(request.Id)
                : new CompanyGetByIdDto
                (
                    CompanyDto: _mapper.Map<CompanySummaryDto>(company),
                    ProjectDtos: _mapper.Map<List<ProjectSummaryDto>>(company.Projects),
                    EmployeeDtos: _mapper.Map<List<EmployeeSummaryDto>>(company.Employees),
                    PositionInCompanyDtos: _mapper.Map<List<PositionInCompanySummaryDto>>(company.Positions),
                    UserDtos: _mapper.Map<List<UserSummaryDto>>(users)
                );
        }
    }
}
