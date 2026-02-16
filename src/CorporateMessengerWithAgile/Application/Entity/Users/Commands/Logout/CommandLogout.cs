using Application.AbsCommand;
using Domain.Result;

namespace Application.Entity.Users.Commands.Logout
{
    public record CommandLogout
        (
            string OldRefreshToken,
            Guid UserId
        )
        : AbsCommand<Result>;
}
