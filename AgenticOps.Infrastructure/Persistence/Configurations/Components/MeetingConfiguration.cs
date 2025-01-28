using AgenticOps.Domain.ValueDelivery.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgenticOps.Infrastructure.Persistence.Configurations.Components
{
    public class MeetingConfiguration : IEntityTypeConfiguration<Meeting>
    {
        public void Configure(EntityTypeBuilder<Meeting> builder)
        {
            builder.ToTable("meetings");

            builder.Property(m => m.Id)
                .HasColumnName("id");

            builder.Property(m => m.Name)
                .HasColumnName("name")
                .IsRequired();
        }
    }
}
