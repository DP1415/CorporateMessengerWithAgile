using Application.AbsCommand;
using AutoMapper;
using Domain.Result;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.Users.Commands.Refresh
{
    internal class CommandRefreshHandler(AppDbContext context, IMapper mapper, IJwtProvider jwtProvider)
        : AbsCommandHandler<CommandRefresh, Result<CommandRefreshOutput>>(context, mapper)
    {
        public override async Task<Result<CommandRefreshOutput>> Handle(CommandRefresh request, CancellationToken cancellationToken)
        {
            RefreshToken? refreshToken = await _context.RefreshTokens
                .Include(rt => rt.User)
                .FirstOrDefaultAsync(
                    rt => rt.Token == request.OldRefreshToken &&
                          rt.UserId == request.UserId,
                    cancellationToken
                );

            if (refreshToken == null) return ApplicationErrors.RefreshTokenError.NotFound;
            if (refreshToken.IsRevoked || refreshToken.ExpiresAt <= DateTime.UtcNow) return ApplicationErrors.RefreshTokenError.Invalid;

            string newRefreshTokenValue = Guid.NewGuid().ToString("N");
            DateTime newRefreshTokenExpiry = DateTime.UtcNow.AddDays(7);

            refreshToken.Token = newRefreshTokenValue;
            refreshToken.ExpiresAt = newRefreshTokenExpiry;
            refreshToken.IsRevoked = false;
            refreshToken.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return new CommandRefreshOutput(newRefreshTokenValue, jwtProvider.GenerateToken(refreshToken.User));
        }
    }
}