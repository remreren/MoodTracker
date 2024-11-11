using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MoodTracker.Api.Infra.Attributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MoodTracker.Api.Infra.Database;

public class BaseDbContext(
    DbContextOptions options,
    IHttpContextAccessor httpContextAccessor
) : IdentityDbContext<IdentityUser>(options)
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

                if (httpContextAccessor.HttpContext?.User == null)
                {
                    continue;
                }

                var email = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!;

                SetPropertyWithAttribute<CreatedByAttribute>(entry, email);
                SetPropertyWithAttribute<LastUpdatedByAttribute>(entry, email);
            }
            else if (entry.State == EntityState.Modified)
            {
                SetPropertyWithAttribute<UpdatedAtAttribute>(entry, time);

                if (httpContextAccessor.HttpContext?.User == null)
                {
                    continue;
                }

                var email = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!;

                SetPropertyWithAttribute<LastUpdatedByAttribute>(entry, email);
            }
        }
    }

    private static void SetPropertyWithAttribute<TAttribute>(EntityEntry entry, object value)
        where TAttribute : Attribute
    {
        var properties = entry.Entity.GetType().GetProperties()
            .Where(p => Attribute.IsDefined(p, typeof(TAttribute)));

        foreach (var property in properties)
        {
            property.SetValue(entry.Entity, value);
        }
    }
}