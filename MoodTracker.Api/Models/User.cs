using System.ComponentModel.DataAnnotations.Schema;
using MoodTracker.Api.Infra.Attributes;

namespace MoodTracker.Api.Models;

[Table("user_table")]
public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Username { get; set; }
    public string PasswordHash { get; set; }
    
    [CreatedAt]
    public DateTime CreatedAt { get; set; }
    
    [UpdatedAt]
    public DateTime UpdatedAt { get; set; }

    public ICollection<Mood> Moods { get; set; } = new List<Mood>();
    
    public override string ToString() => $"User: {Username}";
}