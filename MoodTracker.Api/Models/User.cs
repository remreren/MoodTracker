using System.ComponentModel.DataAnnotations.Schema;

namespace MoodTracker.Api.Models;

[Table("user_table")]
public class User : AuditableEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Username { get; set; }
    public string PasswordHash { get; set; }

    public ICollection<Mood> Moods { get; set; } = new List<Mood>();
}