using Application;
using Application.AbsCommand;
using Application.AbsQuery;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ReactApp.Server.Controllers.Abstract
{
    [ApiController]
    public abstract class BaseController(ISender sender) : ControllerBase
    {
        protected readonly ISender Sender = sender;

        protected Task<TResponse> Send<TResponse>(
            AbsQuery<TResponse> request,
            CancellationToken cancellationToken) => Sender.Send(request, cancellationToken);
    }

    public static class ResultExtensions
    {
        public static ActionResult ToActionResult(this Result result)
            => result.IsSuccess
                ? new StatusCodeResult(result.StatusCode)
                : new ObjectResult(result.Error) { StatusCode = result.Error.StatusCode };

        public static ActionResult<T> ToActionResult<T>(this Result<T> result)
            => new ObjectResult(result.IsSuccess ? result.Value : result.Error) { StatusCode = result.StatusCode };
    }

    [Authorize]
    public abstract class AuthorizedBaseController(ISender sender) : BaseController(sender)
    {
        protected async Task<TResponse> SendAuth<TQuery, TResponse>(
            TQuery request,
            CancellationToken cancellationToken)
            where TQuery : IRequest<TResponse>, IAuthorizedRequest
        {
            string? currentUserId = User.FindFirstValue("currentUserId");
            if (!Guid.TryParse(currentUserId, out var userId)) throw new UnauthorizedAccessException("Неверный или отсутствующий ID пользователя");
            request.CurrentUserId = userId;
            return await Sender.Send<TResponse>(request, cancellationToken);
        }

        //protected async Task<TResult> SendAuthCommand<TCommand, TResult>(
        //    TCommand command,
        //    CancellationToken cancellationToken)
        //    where TCommand : AbsCommand<TResult>, IAuthorizedCommand
        //{
        //    string? currentUserId = User.FindFirstValue("currentUserId");
        //    if (!Guid.TryParse(currentUserId, out var userId)) throw new UnauthorizedAccessException("Неверный или отсутствующий ID пользователя");
        //    command.CurrentUserId = userId;
        //    return await Sender.Send<TResult>(command, cancellationToken);
        //}
    }
}
