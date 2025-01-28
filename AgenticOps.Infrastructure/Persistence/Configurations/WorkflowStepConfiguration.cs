using AgenticOps.Domain.ValueDelivery;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgenticOps.Infrastructure.Persistence.Configurations
{
    public class WorkflowStepConfiguration : IEntityTypeConfiguration<WorkflowStep>
    {
        public void Configure(EntityTypeBuilder<WorkflowStep> builder)
        {
            builder.ToTable("workflow_steps");

            builder.Property(w => w.Id)
                .HasColumnName("id");

            builder.Property(w => w.Name)
                .HasColumnName("name")
                .IsRequired();

            builder.Property(w => w.Description)
                .HasColumnName("description");

            builder.Property(w => w.Index)
                .HasColumnName("index")
                .HasDefaultValue(0);

            builder.Property(w => w.StageId)
                .HasColumnName("stage_id");

            // Many-to-Many relationships
            builder.HasMany(w => w.Roles)
                .WithMany()
                .UsingEntity(j => j.ToTable("workflow_step_roles"));

            builder.HasMany(w => w.Inputs)
                .WithMany()
                .UsingEntity(j => j.ToTable("workflow_step_inputs"));

            builder.HasMany(w => w.Notifications)
                .WithMany()
                .UsingEntity(j => j.ToTable("workflow_step_notifications"));

            builder.HasMany(w => w.Meetings)
                .WithMany()
                .UsingEntity(j => j.ToTable("workflow_step_meetings"));

            builder.HasMany(w => w.Outputs)
                .WithMany()
                .UsingEntity(j => j.ToTable("workflow_step_outputs"));

            builder.HasMany(w => w.Events)
                .WithMany()
                .UsingEntity(j => j.ToTable("workflow_step_events"));

            builder.HasMany(w => w.EventHandlers)
                .WithMany()
                .UsingEntity(j => j.ToTable("workflow_step_event_handlers"));

            builder.HasMany(w => w.AutomationHooks)
                .WithMany()
                .UsingEntity(j => j.ToTable("workflow_step_automation_hooks"));
        }
    }
}
