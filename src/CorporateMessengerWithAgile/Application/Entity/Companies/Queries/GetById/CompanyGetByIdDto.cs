using Application.Dto;

namespace Application.Entity.Companies.Queries.GetById
{
    public record CompanyGetByIdDto(
            CompanyDto CompanyDto,
            List<ProjectDto> ProjectDtos,
            List<EmployeeDto> EmployeeDtos,
            List<PositionInCompanyDto> PositionInCompanyDtos,
            List<UserDto> UserDtos
        );
}
