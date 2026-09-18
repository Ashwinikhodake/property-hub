using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyHub.Domain.Entities;

namespace PropertyHub.Infrastructure.Persistence.Configurations;

public class PropertyConfiguration : IEntityTypeConfiguration<Property>
{
    public void Configure(EntityTypeBuilder<Property> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(5000);
        builder.Property(x => x.Price).IsRequired().HasPrecision(18, 2);
        builder.Property(x => x.PropertyType).IsRequired();
        builder.Property(x => x.ListingType).IsRequired();
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.AreaInSquareFeet).HasPrecision(12, 2);
        builder.Property(x => x.Address).IsRequired().HasMaxLength(500);
        builder.Property(x => x.City).IsRequired().HasMaxLength(100);
        builder.Property(x => x.State).IsRequired().HasMaxLength(100);
        builder.Property(x => x.PostalCode).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Latitude).HasPrecision(9, 6);
        builder.Property(x => x.Longitude).HasPrecision(9, 6);
        builder.HasIndex(x => x.City);
        builder.HasIndex(x => new { x.PropertyType, x.ListingType, x.Status });
        builder.HasOne(x => x.Agent).WithMany(x => x.Properties).HasForeignKey(x => x.AgentId).OnDelete(DeleteBehavior.Restrict);
    }
}