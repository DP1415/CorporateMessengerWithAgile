using Application.Dto.Summary;

namespace Application.Dto
{
    public class EmployeeWithRelationsDto : BaseDto
    {
        public CompanySummaryDto Company { get; set; } = null!;
        public PositionInCompanySummaryDto PositionInCompany { get; set; } = null!;
        public UserSummaryDto User { get; set; } = null!;
        public IReadOnlyList<TeamMemberSummaryDto> TeamMembers { get; set; } = [];
    }
}
