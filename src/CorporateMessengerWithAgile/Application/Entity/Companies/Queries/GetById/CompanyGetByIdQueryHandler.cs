using Application.AbsQuery;
using Application.Dto;
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
                .Include(c => c.Employees)
                .Include(c => c.Positions)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            return
                company is null
                ? new Exception($"Company with ID {request.Id} not found")
                : new CompanyGetByIdDto
                (
                    CompanyDto: _mapper.Map<CompanyDto>(company),
                    ProjectDtos: _mapper.Map<List<ProjectDto>>(company.Projects),
                    EmployeeDtos: _mapper.Map<List<EmployeeDto>>(company.Employees),
                    PositionInCompanyDtos: _mapper.Map<List<PositionInCompanyDto>>(company.Positions)
                );
        }
    }
}
