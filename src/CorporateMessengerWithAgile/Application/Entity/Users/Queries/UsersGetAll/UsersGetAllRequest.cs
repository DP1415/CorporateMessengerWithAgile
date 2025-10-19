using Domain.Entity;

namespace Application.Entity.Users.Queries.UsersGetAll
{
    public record UserDto(
        string Email,
        string Username,
        string PasswordHashed,
        ICollection<Employee> Employees,
        Guid Id,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}
