using Domain.Entity;

namespace Application.Entity.Users.Queries.UsersGetAll
{
    public record UserDto(
        Guid Id,
        string Email,
        string Username,
        DateTime CreatedAt,
        DateTime? UpdatedAt,
        ICollection<Employee> Employees
    );
}
