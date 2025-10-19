using Application.Entity.Users.Commands.UserCreate;
using Application.Entity.Users.Queries.UsersGetAll;
using Domain.Entity;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Abstract;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(ISender sender) : ApiController(sender)
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers(
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

            return CreatedAtAction(nameof(CreateUser), new { id = response });
        }
    }
}