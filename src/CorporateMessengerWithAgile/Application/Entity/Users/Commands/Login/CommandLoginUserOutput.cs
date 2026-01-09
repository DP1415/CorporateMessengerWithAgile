using Application.Dto;

namespace Application.Entity.Users.Commands.Login
{
    public record CommandLoginUserOutput
        (
            string Token,
            UserDto User
        );
}
