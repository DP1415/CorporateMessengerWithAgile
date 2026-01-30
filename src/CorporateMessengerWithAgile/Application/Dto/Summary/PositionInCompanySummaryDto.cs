namespace Application.Dto.Summary
{
    public class PositionInCompanySummaryDto : BaseDto
    {
        public Guid CompanyId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IReadOnlyList<Guid> EmployeeIds { get; set; } = null!;
    }
}
