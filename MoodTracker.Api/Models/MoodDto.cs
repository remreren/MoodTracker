using MoodTracker.Api.Infra.Configuration;
using Newtonsoft.Json;

namespace MoodTracker.Api.Models;

public class MoodDto
{
    [JsonConverter(typeof(IgnoreOnDeserializeConverter))]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    [JsonConverter(typeof(IgnoreOnDeserializeConverter))]
    public DateTime CreatedAt { get; set; }

    [JsonConverter(typeof(IgnoreOnDeserializeConverter))]
    public DateTime UpdatedAt { get; set; }

    public override string ToString() =>
        $"Id: {Id}, Name: {Name}, Description: {Description}, CreatedAt: {CreatedAt}, UpdatedAt: {UpdatedAt}";
}