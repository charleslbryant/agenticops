using AgenticOps.Domain.ValueDelivery.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgenticOps.Infrastructure.Persistence.Configurations.Components
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("events");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Type)
                .HasColumnName("type")
                .IsRequired();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired();
        }
    }
}
