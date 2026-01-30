namespace Application.Dto.Summary
{
    public class TeamMemberSummaryDto : BaseDto
    {
        public Guid EmployeeId { get; set; }
        public Guid TeamId { get; set; }
    }
}
