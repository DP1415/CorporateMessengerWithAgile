namespace Application.Dto.Summary
{
    public class EmployeeSummaryDto : BaseDto
    {
        public Guid CompanyId { get; set; }
        public Guid PositionInCompanyId { get; set; }
        public Guid UserId { get; set; }
        public IReadOnlyList<Guid> TeamMemberIds { get; set; } = null!;
    }
}
