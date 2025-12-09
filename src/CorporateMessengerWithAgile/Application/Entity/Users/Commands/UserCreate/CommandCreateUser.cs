using Application.Command;
using Domain.Entity;

namespace Application.Entity.Users.Commands.UserCreate
{
    public record CommandCreateUser(
        string UserName,
        string Email,
        string Password
        ) : AbsCommandCreateEntity<User>;
}
