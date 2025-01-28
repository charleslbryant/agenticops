using AgenticOps.Domain.ValueDelivery;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgenticOps.Infrastructure.Persistence.Configurations
{
    public class FunnelConfiguration : IEntityTypeConfiguration<Funnel>
    {
        public void Configure(EntityTypeBuilder<Funnel> builder)
        {
            builder.ToTable("funnels");

            builder.Property(f => f.Id)
                .HasColumnName("id");

            builder.Property(f => f.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(f => f.Index)
                .HasColumnName("index")
                .HasDefaultValue(0);

            builder.HasMany(f => f.Phases)
                .WithOne(p => p.Funnel)
                .HasForeignKey(p => p.FunnelId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
