using AgenticOps.Domain.ValueDelivery.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgenticOps.Infrastructure.Persistence.Configurations.Components
{
    public class OutputConfiguration : IEntityTypeConfiguration<Output>
    {
        public void Configure(EntityTypeBuilder<Output> builder)
        {
            builder.ToTable("outputs");

            builder.Property(o => o.Id)
                .HasColumnName("id");

            builder.Property(o => o.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(o => o.Description)
                .HasColumnName("description");
        }
    }
}
