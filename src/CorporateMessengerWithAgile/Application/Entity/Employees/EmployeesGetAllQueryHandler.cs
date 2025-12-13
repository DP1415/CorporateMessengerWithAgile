using Application.Dto;
using Application.Query;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Employees
{
    public class EmployeesGetAllQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryHandler<EmployeesGetAllQuery, Employee, EmployeeDto>(context, mapper);
}
