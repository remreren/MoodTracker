using MoodTracker.Api.Infra.Attributes;
using Microsoft.EntityFrameworkCore;

namespace MoodTracker.Api.Infra.Database;

public class BaseDbContext(DbContextOptions options) : DbContext(options)
{
    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimestamps()
    {
        var time = DateTime.UtcNow;
        foreach (var entry in ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Added)
            {
                SetPropertyWithAttribute<CreatedAtAttribute>(entry, time);
                SetPropertyWithAttribute<UpdatedAtAttribute>(entry, time);
            }
            else if (entry.State == EntityState.Modified)
            {
                SetPropertyWithAttribute<UpdatedAtAttribute>(entry, time);
            }
        }
    }

    private static void SetPropertyWithAttribute<TAttribute>(Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry entry, DateTime value) where TAttribute : Attribute
    {
        var properties = entry.Entity.GetType().GetProperties()
            .Where(p => Attribute.IsDefined(p, typeof(TAttribute)));

        foreach (var property in properties)
        {
            property.SetValue(entry.Entity, value);
        }
    }
}
