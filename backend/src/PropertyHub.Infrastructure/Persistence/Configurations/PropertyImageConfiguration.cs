using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyHub.Domain.Entities;

namespace PropertyHub.Infrastructure.Persistence.Configurations;

public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
{
    public void Configure(EntityTypeBuilder<PropertyImage> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(1000);
        builder.Property(x => x.DisplayOrder).IsRequired();
        builder.HasIndex(x => new { x.PropertyId, x.DisplayOrder });
        builder.HasOne(x => x.Property).WithMany(x => x.Images).HasForeignKey(x => x.PropertyId).OnDelete(DeleteBehavior.Cascade);
    }
}