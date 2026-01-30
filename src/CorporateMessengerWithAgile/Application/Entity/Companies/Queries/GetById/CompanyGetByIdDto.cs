using Application.Dto.Summary;

namespace Application.Entity.Companies.Queries.GetById
{
    public record CompanyGetByIdDto(
            CompanySummaryDto CompanyDto,
            List<ProjectSummaryDto> ProjectDtos,
            List<EmployeeSummaryDto> EmployeeDtos,
            List<PositionInCompanySummaryDto> PositionInCompanyDtos,
            List<UserSummaryDto> UserDtos
        );
}
