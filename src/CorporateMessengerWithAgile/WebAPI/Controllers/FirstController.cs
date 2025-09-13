using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class FirstController : ControllerBase
{
    [HttpGet]
    public int Get()
    {
        return 200;
    }
}
