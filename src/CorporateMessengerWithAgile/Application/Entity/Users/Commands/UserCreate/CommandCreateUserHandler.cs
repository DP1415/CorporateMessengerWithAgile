using Application.Command;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.Users.Commands.UserCreate
{
    public class CommandCreateUserHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreateUser, User, UserDto>(context, mapper)
    {
        public override Result<User> Create(CommandCreateUser request)
        {
            var username = Username.Create(request.UserName);
            if (username.IsFailure) return username.Exception;

            var email = Email.Create(request.Email);
            if (email.IsFailure) return email.Exception;

            var passwordhashed = PasswordHashed.Create(request.Password);
            if (passwordhashed.IsFailure) return passwordhashed.Exception;

            var user = new User
            {
                Username = username,
                Email = email,
                PasswordHashed = passwordhashed
            };
            return user;
        }
    }
}
