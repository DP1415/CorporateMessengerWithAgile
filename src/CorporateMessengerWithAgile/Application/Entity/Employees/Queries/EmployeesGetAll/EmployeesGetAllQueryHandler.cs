using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;
using Application.Dto.Summary;

namespace Application.Entity.Employees.Queries.EmployeesGetAll
{
    public class EmployeesGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityWithOptionsHandler<EmployeesGetAllQuery, Employee, EmployeeSummaryDto>(context, mapper);
}
