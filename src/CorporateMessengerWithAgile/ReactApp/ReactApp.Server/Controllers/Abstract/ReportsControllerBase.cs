using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ReactApp.Server.Controllers.Abstract
{
    [Route("cmwa/reports/[controller]")]
    public abstract class ReportsControllerBase(ISender sender) : AbstractController(sender)
    {
        protected const string ReportsControllerBaseTag = "cmwa/reports";
    }
}
