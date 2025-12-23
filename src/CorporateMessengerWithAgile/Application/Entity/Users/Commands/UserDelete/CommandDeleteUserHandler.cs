using Application.AbsCommand.Delete;
using Domain.Entity;
using Persistence;

namespace Application.Entity.Users.Commands.UserDelete
{
    public class CommandDeleteUserHandler(AppDbContext context) : AbsCommandDeleteEntityByIdHandler<CommandDeleteUser, User>(context);
}
