namespace Application.Dto
{
    public class ProjectDto : BaseDto
    {
        public Guid CompanyId { get; set; }
        public string Title { get; set; } = null!;
        public IReadOnlyList<Guid> TaskItemIds { get; set; } = null!;
        public IReadOnlyList<Guid> TeamIds { get; set; } = null!;
    }
}
