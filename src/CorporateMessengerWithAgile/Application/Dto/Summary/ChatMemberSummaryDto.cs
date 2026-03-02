namespace Application.Dto.Summary
{
    public class ChatMemberSummaryDto : BaseDto
    {
        public Guid ChatId { get; set; }
        public Guid UserId { get; set; }
        public bool IsAdmin { get; set; }
    }
}