using Application.Dto.Summary;
using Application.Entity.Users.Commands.UserChange;
using Application.Entity.Users.Commands.UserCreate;
using Application.Entity.Users.Commands.UserDelete;
using Application.Entity.Users.Queries.UsersGetAll;
using Domain.Entity;
using MediatR;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [Tags(ApiControllerBaseTag)]
    public class UserController(ISender sender) : ApiControllerBase
        <
            User,
            UserSummaryDto,
            UsersGetAllQuery,
            CommandCreateUser,
            CommandUpdateUser,
            CommandDeleteUser
        >(
            sender,
            id => new CommandDeleteUser(id)
        );
}
