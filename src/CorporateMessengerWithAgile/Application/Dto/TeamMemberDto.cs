namespace Application.Dto
{
    public class TeamMemberDto : BaseDto
    {
        public Guid EmployeeId { get; set; }
        public Guid TeamId { get; set; }
    }
}
