using Application.AbsCommand.Create;
using Application.Dto.Summary;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.Users.Commands.UserCreate
{
    public class CommandCreateUserHandler(AppDbContext context, IMapper mapper)
        : AbsCommandCreateEntityHandler<CommandCreateUser, User, UserSummaryDto>(context, mapper)
    {
        public override Result<User> Create(CommandCreateUser request)
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
                Role = request.Role
            };
            return user;
        }
    }
}
