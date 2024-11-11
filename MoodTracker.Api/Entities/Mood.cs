using System.ComponentModel.DataAnnotations.Schema;

namespace MoodTracker.Api.Entities;

public class Mood : AuditableEntity
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public override string ToString() =>
        $"Id: {Id}, Name: {Name}, Description: {Description}, CreatedAt: {CreatedAt}, UpdatedAt: {UpdatedAt}, CreatedBy: {CreatedBy}, LastUpdatedBy: {LastUpdatedBy}";
}