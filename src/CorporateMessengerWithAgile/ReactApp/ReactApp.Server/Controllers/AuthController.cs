using Application.Dto;
using Application.Entity.Users.Commands.Login;
using Application.Entity.Users.Commands.UserCreate;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactApp.Server.Controllers.Abstract;

namespace ReactApp.Server.Controllers
{
    [Route("cmwa/api/[controller]")]
    public class AuthController(ISender sender) : AbstractController(sender)
    {
        [HttpPost("Register")]
        public async Task<Result<UserDto>> Register(
            [FromBody] CommandCreateUser commandCreateUser,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(commandCreateUser, cancellationToken);


        [HttpPost("Login")]
        public async Task<Result<CommandLoginUserOutput>> Login(
            [FromBody] CommandLoginUser commandCreateUser,
            CancellationToken cancellationToken = default
        ) => await Sender.Send(commandCreateUser, cancellationToken);
    }
}
