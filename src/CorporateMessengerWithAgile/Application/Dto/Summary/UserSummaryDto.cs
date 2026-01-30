namespace Application.Dto.Summary
{
    public class UserSummaryDto : BaseDto
    {
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Role { get; set; } = null!;
        public IReadOnlyList<Guid> EmployeeIds { get; set; } = null!;
    }
}
