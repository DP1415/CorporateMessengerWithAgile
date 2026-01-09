using Application.AbsCommand;
using Application.Dto;
using Domain.Result;

namespace Application.Entity.Users.Commands.Login
{
    public record CommandLoginUser
        (
            string UserName,
            string Password
        )
        : AbsCommand<Result<CommandLoginUserOutput>>;
}
