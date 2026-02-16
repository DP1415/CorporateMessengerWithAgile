using Application.AbsCommand;
using Domain.Result;

namespace Application.Entity.Users.Commands.Refresh
{
    public record CommandRefreshOutput
        (
            string RefreshToken,
            string AccessToken
        );

    public record CommandRefresh
        (
            string OldRefreshToken,
            Guid UserId
        )
        : AbsCommand<Result<CommandRefreshOutput>>;

}
