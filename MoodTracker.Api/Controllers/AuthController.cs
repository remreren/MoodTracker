using Microsoft.AspNetCore.Mvc;
using MoodTracker.Api.Models;
using MoodTracker.Api.Services;

namespace MoodTracker.Api.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController(
    UserService userService,
    ILogger<AuthController> logger
) : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public ActionResult Login([FromBody] AuthDto model)
    {
        var authResponse = userService.Login(model);
        if (authResponse == null) return BadRequest();
        return Ok(authResponse);
    }

    [HttpPost]
    [Route("register")]
    public ActionResult Register([FromBody] AuthDto model)
    {
        var authResponse = userService.Register(model);
        return Ok(authResponse);
    }
}