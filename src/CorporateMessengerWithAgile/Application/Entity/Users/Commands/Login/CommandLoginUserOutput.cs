using Application.Dto.Summary;

namespace Application.Entity.Users.Commands.Login
{
    public record CommandLoginUserOutput
        (
            string Token,
            UserSummaryDto User
        );
}
