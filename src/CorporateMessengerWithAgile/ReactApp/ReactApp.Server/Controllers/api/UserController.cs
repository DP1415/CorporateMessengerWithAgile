using Application.Dto;
using Application.Entity.Users.Commands.UserChange;
using Application.Entity.Users.Commands.UserCreate;
using Application.Entity.Users.Commands.UserDelete;
using Application.Entity.Users.Queries.UsersGetAll;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers.api
{
    [ApiController]
    [Route("cmwa/api/[controller]")]
    [Tags("CMWA / API")]
    public class UserController(ISender sender) : ApiController(sender)
    {
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetAll(
            CancellationToken cancellationToken = default
            ) => await Sender.Send(new UsersGetAllQuery(), cancellationToken);

        [HttpPost]
        public async Task<Result<UserDto>> Create(
            [FromBody] CommandCreateUser command,
            CancellationToken cancellationToken = default
            ) => await Sender.Send(command, cancellationToken);

        [HttpDelete("{id}")]
        public async Task<Result> Delete(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default
            ) => await Sender.Send(new CommandDeleteUser(id), cancellationToken);

        [HttpPut]
        public async Task<Result<UserDto>> Change(
            [FromBody] CommandUpdateUser command,
            CancellationToken cancellationToken = default
            ) => await Sender.Send(command, cancellationToken);
    }
}
