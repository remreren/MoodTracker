using AutoMapper;
using MoodTracker.Api.Controllers.Models;
using Microsoft.AspNetCore.Mvc;
using MoodTracker.Api.Entities;

namespace MoodTracker.Api.Controllers;

[ApiController]
[Route("/api/v1/moods")]
public class MoodController(
    ApplicationDbContext context,
    IMapper mapper,
    ILogger<MoodController> logger) : ControllerBase
{
    [HttpPost]
    public ActionResult<MoodDto> CreateMood(MoodDto mood)
    {
        var moodEntity = mapper.Map<MoodDto, Mood>(mood);

        context.Moods.Add(moodEntity);
        context.SaveChanges();

        var response = mapper.Map<Mood, MoodDto>(moodEntity);

        return CreatedAtAction(nameof(GetMood), new { id = moodEntity.Id }, response);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Mood>> ListMoods()
    {
        return context.Moods.ToList();
    }

    [HttpGet("{id}")]
    public ActionResult<MoodDto> GetMood(int id)
    {
        var mood = context.Moods.Find(id);

        if (mood == null)
        {
            return NotFound();
        }

        return mapper.Map<Mood, MoodDto>(mood);
    }
}
