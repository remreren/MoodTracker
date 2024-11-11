namespace MoodTracker.Api.Models;

public class AuthDto(string username, string password)
{
    public string Username { get; set; } = username;
    public string Password { get; set; } = password;
}