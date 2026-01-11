using Application.Dto;
using Application.Entity.Users.Commands.Login;
using Application.Entity.Users.Commands.UserRegister;
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
            [FromBody] CommandRegisterUser commandRegisterUser,
            CancellationToken cancellationToken = default
        ) => (await Sender.Send(commandRegisterUser, cancellationToken)).ToActionResult();


        [HttpPost("Login")]
        public async Task<ActionResult<CommandLoginUserOutput>> Login(
            [FromBody] CommandLoginUser commandLoginUser,
            CancellationToken cancellationToken = default
        ) => (await Sender.Send(commandLoginUser, cancellationToken)).ToActionResult();
    }
}
