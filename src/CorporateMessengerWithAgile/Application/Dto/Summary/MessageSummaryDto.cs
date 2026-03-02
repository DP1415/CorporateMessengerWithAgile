namespace Application.Dto.Summary
{
    public class MessageSummaryDto : BaseDto
    {
        public string Content { get; set; } = null!;
        public Guid ChatId { get; set; }
        public Guid SenderId { get; set; }
        public bool IsEdited { get; set; }
    }
}