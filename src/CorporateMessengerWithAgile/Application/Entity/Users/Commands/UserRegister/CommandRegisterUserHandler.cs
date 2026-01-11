using Application.AbsCommand;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.Users.Commands.UserRegister
{
    public class CommandRegisterUserHandler(AppDbContext context, IMapper mapper)
        : AbsCommandHandler<CommandRegisterUser, Result<UserDto>>(context, mapper)
    {
        public async override Task<Result<UserDto>> Handle(CommandRegisterUser request, CancellationToken cancellationToken)
        {
            var username = Username.Create(request.UserName);
            if (username.IsFailure) return username.Error;

            var email = Email.Create(request.Email);
            if (email.IsFailure) return email.Error;

            var passwordhashed = PasswordHashed.Create(request.Password);
            if (passwordhashed.IsFailure) return passwordhashed.Error;

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHashed = passwordhashed,
                Role = "user"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<UserDto>(user);
        }
    }
}
