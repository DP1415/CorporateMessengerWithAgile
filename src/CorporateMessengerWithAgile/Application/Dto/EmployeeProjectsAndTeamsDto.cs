namespace Application.Dto
{
    public class EmployeeProjectsAndTeamsDto
    {
        public IReadOnlyList<ProjectDto> Projects { get; set; } = null!;
        public IReadOnlyList<TeamDto> Teams { get; set; } = null!;
    }
}
