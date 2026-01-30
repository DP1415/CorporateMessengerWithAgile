namespace Application.Dto.Summary
{
    public class CompanySummaryDto : BaseDto
    {
        public string Title { get; set; } = null!;
        public IReadOnlyList<Guid> EmployeeIds { get; set; } = null!;
        public IReadOnlyList<Guid> PositionIds { get; set; } = null!;
        public IReadOnlyList<Guid> ProjectIds { get; set; } = null!;
    }
}
