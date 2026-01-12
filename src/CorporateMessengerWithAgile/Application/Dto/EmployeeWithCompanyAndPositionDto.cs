namespace Application.Dto
{
    public class EmployeeWithCompanyAndPositionDto : BaseDto
    {
        public CompanyDto Company { get; set; } = null!;
        public PositionInCompanyDto PositionInCompany { get; set; } = null!;
        public UserDto User { get; set; } = null!;
        public IReadOnlyList<TeamMemberDto> TeamMembers { get; set; } = [];
    }
}
