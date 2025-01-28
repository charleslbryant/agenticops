using AgenticOps.Domain.ValueDelivery.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgenticOps.Infrastructure.Persistence.Configurations.Components
{
    public class AutomationHookConfiguration : IEntityTypeConfiguration<AutomationHook>
    {
        public void Configure(EntityTypeBuilder<AutomationHook> builder)
        {
            builder.ToTable("automation_hooks");

            builder.Property(a => a.Id)
                .HasColumnName("id");

            builder.Property(a => a.System)
                .HasColumnName("system")
                .IsRequired();

            builder.Property(a => a.ApiCall)
                .HasColumnName("api_call")
                .IsRequired();
        }
    }
}
