using Application.Entity.Users.Commands.UserCreate;
using Application.Entity.Users.Commands.UserDelete;
using Application.Entity.Users.Queries.UsersGetAll;
using Domain.Entity;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAPI.Controllers.Abstract;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(ISender sender) : ApiController(sender)
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers(
            CancellationToken cancellationToken = default
            ) => await Sender.Send(new UsersGetAllQuery(), cancellationToken);

        [HttpPost]
        public async Task<Result<User>> CreateUser(
            [FromBody] CommandCreateUser command,
            CancellationToken cancellationToken = default
            ) => await Sender.Send(command, cancellationToken);

        [HttpDelete("{id}")]
        public async Task<Result> DeleteUser(
            [FromRoute] Guid id,
            CancellationToken cancellationToken = default
            ) => await Sender.Send(new CommandDeleteUser(id), cancellationToken);
    }
}