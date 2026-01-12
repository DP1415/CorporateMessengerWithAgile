using Application.AbsQuery;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Employees.Queries.EmployeeGetByUserId
{
    public class EmployeeGetByUserIdQueryHandler(AppDbContext context, IMapper mapper)
        : AbsQueryEntityWithOptionsHandler<
            EmployeeGetByUserIdQuery,
            Employee,
            EmployeeWithCompanyAndPositionDto
            >(context, mapper);
}
