using Application.AbsQuery;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Employees.Queries.EmployeeGetByUsername
{
    public class EmployeeGetByUsernameQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityWithOptionsHandler<EmployeeGetByUsernameQuery, Employee, EmployeeWithRelationsDto>(context, mapper);
}
