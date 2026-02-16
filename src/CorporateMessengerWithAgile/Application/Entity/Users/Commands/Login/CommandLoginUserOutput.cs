using Application.Dto.Summary;

namespace Application.Entity.Users.Commands.Login
{
    public record CommandLoginUserOutput
        (
            string RefreshToken,
            string AccessToken,
            UserSummaryDto User
        );
}
