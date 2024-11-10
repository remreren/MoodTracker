using System.ComponentModel.DataAnnotations.Schema;
using MoodTracker.Api.Infra.Attributes;

namespace MoodTracker.Api.Entities;

public class User
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Email { get; set; }
    public string Password { get; set; }
    public List<Mood> Moods { get; set; }

    [CreatedAt]
    public DateTime CreatedAt { get; }

    [UpdatedAt]
    public DateTime UpdatedAt { get; }
}
