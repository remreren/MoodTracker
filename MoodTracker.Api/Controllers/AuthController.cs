using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoodTracker.Api.Infra.Auth;
using MoodTracker.Api.Models;

namespace MoodTracker.Api.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController(
    UserManager<IdentityUser> userManager,
    AuthService authService,
    ILogger<AuthController> logger
) : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public async Task<ActionResult> Login([FromBody] AuthDto model)
    {
        var user = await userManager.FindByEmailAsync(model.Username);

        if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
            return Unauthorized(new { Message = "Invalid login credentials" });

        var token = authService.GenerateJwtToken(user);
        return Ok(new { Token = token });
    }

    [HttpPost]
    [Route("register")]
    public async Task<ActionResult> Register([FromBody] AuthDto model)
    {
        var user = new IdentityUser { UserName = model.Username, Email = model.Username };
        var result = await userManager.CreateAsync(user, model.Password);

        if (!result.Succeeded) return BadRequest(result.Errors);

        return Ok(new { Message = "Registration successful" });
    }
}