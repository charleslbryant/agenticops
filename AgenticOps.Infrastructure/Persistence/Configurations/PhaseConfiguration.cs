using AgenticOps.Domain.ValueDelivery;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgenticOps.Infrastructure.Persistence.Configurations
{
    public class PhaseConfiguration : IEntityTypeConfiguration<Phase>
    {
        public void Configure(EntityTypeBuilder<Phase> builder)
        {
            builder.ToTable("phases");

            builder.Property(p => p.Id)
                .HasColumnName("id");

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(p => p.Index)
                .HasColumnName("index")
                .HasDefaultValue(0);

            builder.Property(p => p.FunnelId)
                .HasColumnName("funnel_id");

            builder.HasMany(p => p.Stages)
                .WithOne(s => s.Phase)
                .HasForeignKey(s => s.PhaseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
