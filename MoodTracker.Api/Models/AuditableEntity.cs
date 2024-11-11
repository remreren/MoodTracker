using MoodTracker.Api.Infra.Attributes;

namespace MoodTracker.Api.Models;

public abstract class AuditableEntity
{

    [CreatedAt]
    public DateTime CreatedAt { get; set; }

    [UpdatedAt]
    public DateTime UpdatedAt { get; set; }
    
    [CreatedBy]
    public string CreatedBy { get; set; }
    
    [LastUpdatedBy]
    public string LastUpdatedBy { get; set; }
}