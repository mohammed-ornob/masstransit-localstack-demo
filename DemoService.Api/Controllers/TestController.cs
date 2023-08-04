using Microsoft.AspNetCore.Mvc;

namespace DemoService.Api.Controllers;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{
    // GET
    public IActionResult Get()
    {
        return Ok();
    }
}