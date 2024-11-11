using AutoMapper;
using MoodTracker.Api.Entities;
using MoodTracker.Api.Models;

namespace MoodTracker.Api.Configuration;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Mood, MoodDto>();
        CreateMap<MoodDto, Mood>();
    }
}