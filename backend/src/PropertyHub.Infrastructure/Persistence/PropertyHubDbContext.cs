using Microsoft.EntityFrameworkCore;
using PropertyHub.Domain.Entities;

namespace PropertyHub.Infrastructure.Persistence;

public class PropertyHubDbContext : DbContext
{
    public PropertyHubDbContext(DbContextOptions<PropertyHubDbContext> options) : base(options) { }
    public DbSet<User> Users => Set<User>();
    public DbSet<Property> Properties => Set<Property>();
    public DbSet<PropertyImage> PropertyImage => Set<PropertyImage>();
    public DbSet<PropertyVisit> PropertyVisits => Set<PropertyVisit>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PropertyHubDbContext).Assembly);
    }

}