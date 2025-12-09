using Application.Entity.Users.Commands.UserCreate;
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
        [SwaggerResponse(200, "Success", typeof(Nullable))]
        public async Task<Result<Guid>> CreateUser(
            [FromBody] CommandCreateUser command,
            CancellationToken cancellationToken = default
            ) => await Sender.Send(command, cancellationToken);
    }
}