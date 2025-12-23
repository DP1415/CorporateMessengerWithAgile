using Application.AbsCommand.Delete;
using Domain.Entity;

namespace Application.Entity.Users.Commands.UserDelete
{
    public record CommandDeleteUser(Guid Id) : AbsCommandDeleteEntityById<User>(Id);
}
