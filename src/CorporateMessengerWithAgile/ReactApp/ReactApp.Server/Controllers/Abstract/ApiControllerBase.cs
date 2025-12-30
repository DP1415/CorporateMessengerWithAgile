using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Server.Controllers.Abstract
{
    [Route("cmwa/api/[controller]")]
    public abstract class ApiControllerBase(ISender sender) : AbstractController(sender)
    {
        protected const string ApiControllerBaseTag = "cmwa/api";
    }
}
