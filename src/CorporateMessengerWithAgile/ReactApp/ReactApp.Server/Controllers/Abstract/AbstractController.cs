using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Server.Controllers.Abstract
{
    [ApiController]
    public abstract class AbstractController(ISender sender) : ControllerBase
    {
        protected readonly ISender Sender = sender;
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
}
