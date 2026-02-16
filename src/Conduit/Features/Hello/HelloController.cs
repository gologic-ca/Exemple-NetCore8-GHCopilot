using Microsoft.AspNetCore.Mvc;

namespace Conduit.Features.Hello;

[Route("hello")]
public class HelloController : Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { message = "Hello World" });
    }
}
