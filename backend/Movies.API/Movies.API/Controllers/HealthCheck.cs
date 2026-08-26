using Microsoft.AspNetCore.Mvc;

namespace Movies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthCheck : ControllerBase
{
    [HttpGet]
    public IActionResult Check()
    {
        return Ok("The API is working!");
    }
}
