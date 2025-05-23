using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Controller]
[Route("api/ping")]
public class HealthCheckController : ControllerBase
{
    [HttpGet]
    public IActionResult Ping()
    {
        return Ok("pong :)");
    }
}
