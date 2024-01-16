using FastLinker.Domain;
using FastLinker.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace FastLinker.Persistence.DatabaseContexts;

public class FastLinkerContext : DbContext
{
    public FastLinkerContext(DbContextOptions<FastLinkerContext> options) : base(options)
    {
    }

    public DbSet<Link> Links { get; set; }
    public DbSet<ShortLink> ShortLinks { get; set; }
    public DbSet<Click> Clicks { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var item in base.ChangeTracker.Entries<BaseEntity>().Where(e => e.State == EntityState.Added))
        {
            if (item.State == EntityState.Added)
            {
                item.Entity.CreationDateTime = DateTime.Now;
            }

        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FastLinkerContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
