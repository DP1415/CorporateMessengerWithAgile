namespace Application.Dto
{
    public class SprintDto : BaseDto
    {
        public Guid TeamId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public IReadOnlyList<Guid> TaskItemIds { get; set; } = null!;
    }
}
