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
            if (username.IsFailure) return username.Exception;

            var passwordhashed = PasswordHashed.Create(request.Password);
            if (passwordhashed.IsFailure) return passwordhashed.Exception;

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username.Value == username.Value.Value, cancellationToken);

            if (user == null || !user.PasswordHashed.Equals(passwordhashed.Value))
                return new Exception("Invalid username or password");

            string token = jwtProvider.GenerateToken(user);
            return new CommandLoginUserOutput(token, _mapper.Map<UserDto>(user));
        }
    }
}
