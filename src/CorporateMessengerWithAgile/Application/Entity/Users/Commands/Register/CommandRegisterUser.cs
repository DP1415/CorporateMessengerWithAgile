using Application.AbsCommand;
using Application.Dto;
using Domain.Result;

namespace Application.Entity.Users.Commands.Register
{
    public record CommandRegisterUser
        (
            string UserName,
            string Email,
            string Password
        )
        : AbsCommand<Result<UserDto>>;
}
