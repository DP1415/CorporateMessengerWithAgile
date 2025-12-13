using Application.Command;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Users.Commands.UserChange
{
    public record CommandUpdateUser
        (
            Guid Id,
            string? UserName,
            string? Email,
            string? Password
        )
        : AbsCommandUpdateEntityById<User, UserDto>(Id);
}
