using AgenticOps.Domain.ValueDelivery.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgenticOps.Infrastructure.Persistence.Configurations.Components
{
    public class InputConfiguration : IEntityTypeConfiguration<Input>
    {
        public void Configure(EntityTypeBuilder<Input> builder)
        {
            builder.ToTable("inputs");

            builder.Property(i => i.Id)
                .HasColumnName("id");

            builder.Property(i => i.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(i => i.Source)
                .HasColumnName("source");
        }
    }
}
