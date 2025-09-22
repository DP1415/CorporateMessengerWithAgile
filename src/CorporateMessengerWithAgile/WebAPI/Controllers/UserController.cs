using Application.Entity.Users.Commands.UserCreate;
using Application.Entity.Users.Queries.UsersGetAll;
using Domain.Entity;
using Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ISender Sender;

        public UserController(ISender sender)
        {
            Sender = sender;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers(
            CancellationToken cancellationToken = default
            )
        {
            return await Sender.Send(new UsersGetAllQuery(), cancellationToken);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(
            [FromBody] UserCreateCommand command,
            CancellationToken cancellationToken = default
            )
        {
            var response = await Sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetAllUsers), new { id = response });
        }
    }
}