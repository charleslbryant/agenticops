using AgenticOps.Domain.ValueDelivery.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgenticOps.Infrastructure.Persistence.Configurations.Components
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("roles");

            builder.Property(r => r.Id)
                .HasColumnName("id");

            builder.Property(r => r.Title)
                .HasColumnName("title")
                .IsRequired();

            builder.Property(r => r.Responsibilities)
                .HasColumnName("responsibilities");
        }
    }
}
