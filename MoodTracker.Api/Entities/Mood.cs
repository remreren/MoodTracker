using System.ComponentModel.DataAnnotations.Schema;
using MoodTracker.Api.Infra.Attributes;

namespace MoodTracker.Api.Entities;

public class Mood
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string Name { get; set; }
    public string Description { get; set; }

    [CreatedAt]
    public DateTime CreatedAt { get; set; }

    [UpdatedAt]
    public DateTime UpdatedAt { get; set; }
    
    public override string ToString() => $"Id: {Id}, Name: {Name}, Description: {Description}, CreatedAt: {CreatedAt}, UpdatedAt: {UpdatedAt}";
}