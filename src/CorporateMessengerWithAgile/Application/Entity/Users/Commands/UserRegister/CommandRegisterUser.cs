using Application.AbsCommand;
using Application.Dto;
using Domain.Entity;
using Domain.Result;

namespace Application.Entity.Users.Commands.UserRegister
{
    public record CommandRegisterUser
        (
            string UserName,
            string Email,
            string Password
        )
        : AbsCommand<Result<UserDto>>;
}
