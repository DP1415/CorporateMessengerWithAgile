using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Server.Controllers.Abstract
{
    [ApiController]
    public abstract class AbstractController(ISender sender) : ControllerBase
    {
        protected readonly ISender Sender = sender;
    }
}
