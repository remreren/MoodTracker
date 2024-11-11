using Microsoft.EntityFrameworkCore;
using MoodTracker.Api.Infra.Database;

namespace MoodTracker.Api.Entities;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor accessor) : BaseDbContext(options, accessor)
{
    public DbSet<Mood> Moods { get; set; }
    public DbSet<User> Users { get; set; }
}