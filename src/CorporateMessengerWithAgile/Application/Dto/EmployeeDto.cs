namespace Application.Dto
{
    public class EmployeeDto : BaseDto
    {
        public Guid CompanyId { get; set; }
        public Guid PositionInCompanyId { get; set; }
        public Guid UserId { get; set; }
        public IReadOnlyList<Guid> TeamMemberIds { get; set; } = null!;
    }
}
