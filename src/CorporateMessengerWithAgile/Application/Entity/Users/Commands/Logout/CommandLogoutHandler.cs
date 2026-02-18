using Application.AbsCommand;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.Users.Commands.Logout
{
    public class CommandLogoutHandler(AppDbContext context, IMapper mapper, IJwtProvider jwtProvider)
        : AbsCommandHandler<CommandLogout, Result>(context, mapper)
    {
        public override async Task<Result> Handle(CommandLogout request, CancellationToken cancellationToken)
        {
            RefreshToken? refreshToken = await _context.RefreshTokens
                .FirstOrDefaultAsync(
                    rt => rt.UserId == request.UserId &&
                          rt.Token == request.OldRefreshToken,
                    cancellationToken
                );

            if (refreshToken == null) return ApplicationErrors.RefreshTokenError.NotFound;

            refreshToken.IsRevoked = true;
            refreshToken.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success(StatusCodes.Status204NoContent);
        }
    }
}
