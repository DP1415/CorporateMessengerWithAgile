namespace Application.Dto.Summary
{
    public class ChatSummaryDto : BaseDto
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public Guid? OwnerEmployeeId { get; set; }
        public Guid? OwnerTeamId { get; set; }
    }
}