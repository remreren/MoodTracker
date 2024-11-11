using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace MoodTracker.Api.Controllers;

[Produces(MediaTypeNames.Application.Json)]
[Route("api/v1/hello")]
[ApiController]
public class HelloWorldController : ControllerBase {
    
    [HttpGet]
    public ActionResult<string> Hello() {
        return Ok("Hello!");
    }
}