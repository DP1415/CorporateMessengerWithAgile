using Application.AbsCommand;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.Users.Commands.Register
{
    public class CommandRegisterUserHandler(AppDbContext context, IMapper mapper)
        : AbsCommandHandler<CommandRegisterUser, Result<UserSummaryDto>>(context, mapper)
    {
        public async override Task<Result<UserSummaryDto>> Handle(CommandRegisterUser request, CancellationToken cancellationToken)
        {
            var username = Username.Create(request.UserName);
            if (username.IsFailure) return username.Error;

            var email = Email.Create(request.Email);
            if (email.IsFailure) return email.Error;

            var passwordhashed = PasswordHashed.Create(request.Password);
            if (passwordhashed.IsFailure) return passwordhashed.Error;

            User? existUser = await _context.Users
                .FirstOrDefaultAsync(
                    existUser =>
                        existUser.Username.Value == username.Value.Value ||
                        existUser.Email.Value == email.Value.Value,
                    cancellationToken
                );
            if (existUser != null) return ApplicationErrors.RegisterError.UserExist;

            User user = new()
            {
                Username = username,
                Email = email,
                PasswordHashed = passwordhashed,
                Role = "user",
                RefreshToken = new()
                {
                    Token = string.Empty,
                    ExpiresAt = DateTime.UtcNow,
                    IsRevoked = true,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                }
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success(_mapper.Map<UserSummaryDto>(user), StatusCodes.Status201Created);
        }
    }
}
