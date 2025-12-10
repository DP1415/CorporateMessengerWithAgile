using Application.Command;
using Domain.Entity;
using Domain.Result;
using Domain.ValueObjects;
using Persistence;

namespace Application.Entity.Users.Commands.UserChange
{
    public class CommandChangeUserHandler(AppDbContext context) : AbsCommandUpdateEntityByIdHandler<CommandChangeUser, User>(context)
    {
        protected override Result<User> Update(User entity, CommandChangeUser request)
        {
            if (request.UserName != null)
            {
                var username = Username.Create(request.UserName);
                if (username.IsFailure) return username.Exception;
                entity.Username = username;
            }


            if (request.Email != null)
            {
                var email = Email.Create(request.Email);
                if (email.IsFailure) return email.Exception;
                entity.Email = email;
            }

            if (request.Password != null)
            {
                var passwordhashed = PasswordHashed.Create(request.Password);
                if (passwordhashed.IsFailure) return passwordhashed.Exception;
                entity.PasswordHashed = passwordhashed;
            }

            return entity;
        }
    }
}
