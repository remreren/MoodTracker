using MoodTracker.Api.Database;
using MoodTracker.Api.Infra.Auth;
using MoodTracker.Api.Models;

namespace MoodTracker.Api.Services;

public class UserService(
    ApplicationDbContext context,
    AuthService authService,
    ILogger<UserService> logger
)
{
    public AuthResponse Register(AuthDto model)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
        var user = new User { Username = model.Username, PasswordHash = passwordHash };

        context.Users.Add(user);
        context.SaveChanges();

        // var token = authService.GenerateJwtToken(user);

        return new AuthResponse { Username = user.Username, Token = "token" };
    }

    public AuthResponse? Login(AuthDto model)
    {
        var user = context.Users.FirstOrDefault(u => u.Username == model.Username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            return null;

        // var token = authService.GenerateJwtToken(user);

        return new AuthResponse { Username = user.Username, Token = "token" };
    }
}