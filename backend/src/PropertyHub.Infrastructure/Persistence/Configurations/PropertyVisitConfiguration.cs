using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PropertyHub.Domain.Entities;

namespace PropertyHub.Infrastructure.Persistence.Configurations;

public class PropertyVisitConfiguration : IEntityTypeConfiguration<PropertyVisit>
{
    public void Configure(EntityTypeBuilder<PropertyVisit> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.ScheduledAt).IsRequired();
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.CustomerNote).HasMaxLength(1000);
        builder.Property(x => x.AgentNote).HasMaxLength(1000);
        builder.HasIndex(x => new { x.PropertyId, x.ScheduledAt });
        builder.HasIndex(x => new { x.UserId, x.Status });

        builder.HasOne(x => x.User).WithMany(x => x.PropertyVisits).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(x => x.Property).WithMany(x => x.Visits).HasForeignKey(x => x.PropertyId).OnDelete(DeleteBehavior.Restrict);

    }
}