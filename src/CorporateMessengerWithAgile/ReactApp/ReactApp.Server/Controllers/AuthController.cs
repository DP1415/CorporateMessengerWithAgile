using Application.Dto.Summary;
using Application.Entity.Users.Commands.Register;
using Application.Entity.Users.Commands.Login;
using Application.Entity.Users.Commands.Refresh;
using Application.Entity.Users.Commands.Logout;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers
{
    [Route("cmwa/[controller]")]
    public class AuthController(ISender sender) : AbstractController(sender)
    {
        [HttpPost("Register")]
        public async Task<ActionResult<UserSummaryDto>> Register(
            [FromBody] CommandRegisterUser commandRegisterUser,
            CancellationToken cancellationToken = default
        ) => (await Sender.Send(commandRegisterUser, cancellationToken)).ToActionResult();

        [HttpPost("Login")]
        public async Task<ActionResult<CommandLoginUserOutput>> Login(
            [FromBody] CommandLoginUser commandLoginUser,
            CancellationToken cancellationToken = default
        ) => (await Sender.Send(commandLoginUser, cancellationToken)).ToActionResult();

        [HttpPost("Refresh")]
        public async Task<ActionResult<CommandRefreshOutput>> Refresh(
            [FromBody] CommandRefresh commandRefresh,
            CancellationToken cancellationToken = default
        ) => (await Sender.Send(commandRefresh, cancellationToken)).ToActionResult();

        [HttpPost("Logout")]
        public async Task<ActionResult> Logout(
            [FromBody] CommandLogout commandLogout,
            CancellationToken cancellationToken = default
        ) => (await Sender.Send(commandLogout, cancellationToken)).ToActionResult();
    }
}
