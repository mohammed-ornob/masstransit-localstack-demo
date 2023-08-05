using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace DemoService.Api.Controllers;

[ApiController]
[Route("test")]
public class TestController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public TestController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    // GET
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        await _publishEndpoint.Publish(new DemoMessage("Hello World!!!"), CancellationToken.None);
        
        return Ok();
    }
}