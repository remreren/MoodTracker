using Microsoft.EntityFrameworkCore;
using MoodTracker.Api.Infra.Database;
using MoodTracker.Api.Models;

namespace MoodTracker.Api.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor accessor)
    : BaseDbContext(options, accessor)
{
    public DbSet<Mood> Moods { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>()
            .HasMany(m => m.Moods)
            .WithOne(u => u.User)
            .HasForeignKey(m => m.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(builder);
    }
}