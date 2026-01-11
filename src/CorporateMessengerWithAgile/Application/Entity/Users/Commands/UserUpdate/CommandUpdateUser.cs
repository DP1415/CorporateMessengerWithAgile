using Application.AbsCommand.Update;
using Application.Dto;
using Domain.Entity;

namespace Application.Entity.Users.Commands.UserChange
{
    public record CommandUpdateUser
        (
            Guid Id,
            string? UserName,
            string? Email,
            string? Password,
            string? Role
        )
        : AbsCommandUpdateEntityById<User, UserDto>(Id);
}
