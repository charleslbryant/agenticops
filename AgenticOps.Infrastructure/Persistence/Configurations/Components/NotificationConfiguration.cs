using AgenticOps.Domain.ValueDelivery.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgenticOps.Infrastructure.Persistence.Configurations.Components
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("notifications");

            builder.Property(n => n.Id)
                .HasColumnName("id");

            builder.Property(n => n.Notice)
                .HasColumnName("notice")
                .IsRequired();

            builder.Property(n => n.Recipients)
                .HasColumnName("recipients");
        }
    }
}
