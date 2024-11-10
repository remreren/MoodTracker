using AutoMapper;
using MoodTracker.Api.Controllers.Models;
using MoodTracker.Api.Entities;

namespace MoodTracker.Api.Configuration;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Mood, MoodDto>();
        CreateMap<MoodDto, Mood>();
    }
}