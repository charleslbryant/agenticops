using AgenticOps.Domain.ValueDelivery.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgenticOps.Infrastructure.Persistence.Configurations.Components
{
    public class WorkflowEventHandlerConfiguration : IEntityTypeConfiguration<WorkflowEventHandler>
    {
        public void Configure(EntityTypeBuilder<WorkflowEventHandler> builder)
        {
            builder.ToTable("event_handlers");

            builder.Property(e => e.Id)
                .HasColumnName("id");

            builder.Property(e => e.Event)
                .HasColumnName("event")
                .IsRequired();

            builder.Property(e => e.Condition)
                .HasColumnName("condition");

            builder.Property(e => e.Action)
                .HasColumnName("action")
                .IsRequired();
        }
    }
}
