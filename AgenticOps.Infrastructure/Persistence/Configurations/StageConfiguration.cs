using AgenticOps.Domain.ValueDelivery;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgenticOps.Infrastructure.Persistence.Configurations
{
    public class StageConfiguration : IEntityTypeConfiguration<Stage>
    {
        public void Configure(EntityTypeBuilder<Stage> builder)
        {
            builder.ToTable("stages");

            builder.Property(s => s.Id)
                .HasColumnName("id");

            builder.Property(s => s.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(s => s.Purpose)
                .HasColumnName("purpose");

            builder.Property(s => s.Goal)
                .HasColumnName("goal");

            builder.Property(s => s.Index)
                .HasColumnName("index")
                .HasDefaultValue(0);

            builder.Property(s => s.PhaseId)
                .HasColumnName("phase_id");

            builder.HasMany(s => s.Steps)
                .WithOne(w => w.Stage)
                .HasForeignKey(w => w.StageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
