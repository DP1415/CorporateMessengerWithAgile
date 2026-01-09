using Application.AbsCommand;
using Application.Dto;
using AutoMapper;
using Domain;
using Domain.Result;
using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Entity.Users.Commands.Login
{
    public class CommandLoginUserHandler(AppDbContext context, IMapper mapper, IJwtProvider jwtProvider)
        : AbsCommandHandler<CommandLoginUser, Result<CommandLoginUserOutput>>(context, mapper)
    {
        protected readonly IJwtProvider jwtProvider = jwtProvider;

        public async override Task<Result<CommandLoginUserOutput>> Handle(CommandLoginUser request, CancellationToken cancellationToken)
        {
            var username = Username.Create(request.UserName);
            if (username.IsFailure) return username.Error;

            var passwordhashed = PasswordHashed.Create(request.Password);
            if (passwordhashed.IsFailure) return passwordhashed.Error;

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username.Value == username.Value.Value, cancellationToken);

            if (user == null || !user.PasswordHashed.Equals(passwordhashed.Value))
                return new Error("Invalid username or password", "Invalid username or password");

            string token = jwtProvider.GenerateToken(user);
            return new CommandLoginUserOutput(token, _mapper.Map<UserDto>(user));
        }
    }
}
