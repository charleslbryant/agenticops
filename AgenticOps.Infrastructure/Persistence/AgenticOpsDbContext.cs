using System.Threading;
using System.Threading.Tasks;
using AgenticOps.Domain.Common;
using AgenticOps.Domain.ValueDelivery;
using AgenticOps.Domain.ValueDelivery.Components;
using Microsoft.EntityFrameworkCore;

namespace AgenticOps.Infrastructure.Persistence
{
    public class AgenticOpsDbContext : DbContext
    {
        private readonly string _userId;

        public AgenticOpsDbContext(DbContextOptions<AgenticOpsDbContext> options, string userId = "system") 
            : base(options)
        {
            _userId = userId;
        }

        public DbSet<Funnel> Funnels { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<WorkflowStep> WorkflowSteps { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Input> Inputs { get; set; }
        public DbSet<Output> Outputs { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<WorkflowEventHandler> EventHandlers { get; set; }
        public DbSet<AutomationHook> AutomationHooks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AgenticOpsDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.SetCreatedBy(_userId);
                        break;
                    case EntityState.Modified:
                        entry.Entity.SetLastUpdatedBy(_userId);
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
