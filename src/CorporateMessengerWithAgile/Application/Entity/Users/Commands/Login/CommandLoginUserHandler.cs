using Application.AbsCommand;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.Users.Commands.Login
{
    public class CommandLoginUserHandler(AppDbContext context, IMapper mapper, IJwtProvider jwtProvider)
        : AbsCommandHandler<CommandLoginUser, Result<CommandLoginUserOutput>>(context, mapper)
    {
        public async override Task<Result<CommandLoginUserOutput>> Handle(CommandLoginUser request, CancellationToken cancellationToken)
        {
            var username = Username.Create(request.UserName);
            if (username.IsFailure) return username.Error;

            var passwordhashed = PasswordHashed.Create(request.Password);
            if (passwordhashed.IsFailure) return passwordhashed.Error;

            User? user = await _context.Users
                .Include(u => u.RefreshToken)
                .FirstOrDefaultAsync(
                    u => u.Username.Value == username.Value.Value,
                    cancellationToken
                );

            if (user == null || !user.PasswordHashed.Equals(passwordhashed.Value))
                return ApplicationErrors.AuthenticationError.Invalid;

            string refreshTokenValue = Guid.NewGuid().ToString("N"); // 32 символа без дефисов
            DateTime refreshTokenExpiry = DateTime.UtcNow.AddDays(7);

            if (user.RefreshToken != null)
            {
                user.RefreshToken.Token = refreshTokenValue;
                user.RefreshToken.ExpiresAt = refreshTokenExpiry;
                user.RefreshToken.IsRevoked = false;
                user.RefreshToken.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                // wip удалить этот блок
                user.RefreshToken = new RefreshToken
                {
                    UserId = user.Id,
                    Token = refreshTokenValue,
                    ExpiresAt = refreshTokenExpiry,
                    IsRevoked = false,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                _context.RefreshTokens.Add(user.RefreshToken);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return new CommandLoginUserOutput(
                    refreshTokenValue,
                    jwtProvider.GenerateToken(user),
                    _mapper.Map<UserSummaryDto>(user)
                );
        }
    }
}
