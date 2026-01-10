using Application.Dto;
using Application.Entity.Users.Commands.Login;
using Application.Entity.Users.Commands.UserCreate;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers
{
    [Route("cmwa/api/[controller]")]
    public class AuthController(ISender sender) : AbstractController(sender)
    {
        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(
            [FromBody] CommandCreateUser commandCreateUser,
            CancellationToken cancellationToken = default
        ) => (await Sender.Send(commandCreateUser, cancellationToken)).ToActionResult();


        [HttpPost("Login")]
        public async Task<ActionResult<CommandLoginUserOutput>> Login(
            [FromBody] CommandLoginUser commandCreateUser,
            CancellationToken cancellationToken = default
        ) => (await Sender.Send(commandCreateUser, cancellationToken)).ToActionResult();
    }
}
