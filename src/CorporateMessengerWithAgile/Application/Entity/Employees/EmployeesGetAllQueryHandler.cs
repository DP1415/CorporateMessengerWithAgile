using Application.Dto;
using Application.AbsQuery;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Employees
{
    public class EmployeesGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryGetAllEntityHandler<EmployeesGetAllQuery, Employee, EmployeeDto>(context, mapper);
}
