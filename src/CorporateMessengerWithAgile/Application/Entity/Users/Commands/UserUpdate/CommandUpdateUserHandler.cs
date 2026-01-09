using Application.AbsCommand.Update;
using Application.Dto;
using AutoMapper;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.Users.Commands.UserChange
{
    public class CommandUpdateUserHandler(AppDbContext context, IMapper mapper)
        : AbsCommandUpdateEntityByIdHandler<CommandUpdateUser, User, UserDto>(context, mapper)
    {
        protected override Result<User> Update(User entity, CommandUpdateUser request)
        {
            if (request.UserName is not null)
            {
                var username = Username.Create(request.UserName);
                if (username.IsFailure) return username.Error;
                entity.Username = username;
            }

            if (request.Email is not null)
            {
                var email = Email.Create(request.Email);
                if (email.IsFailure) return email.Error;
                entity.Email = email;
            }

            if (request.Password is not null)
            {
                var passwordhashed = PasswordHashed.Create(request.Password);
                if (passwordhashed.IsFailure) return passwordhashed.Error;
                entity.PasswordHashed = passwordhashed;
            }

            return entity;
        }
    }
}
