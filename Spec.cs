namespace Application.Models
{
    // Represents the highest level of the workflow hierarchy
    public class Funnel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Index { get; set; } // Allows sorting
        public List<Phase> Phases { get; set; } = new();
    }

    // Represents a phase within a funnel
    public class Phase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Index { get; set; } // Allows sorting
        public int FunnelId { get; set; } // Parent reference
        public Funnel Funnel { get; set; }
        public List<Stage> Stages { get; set; } = new();
    }

    // Represents a stage within a phase, containing purpose, goal, workflow steps, and metrics
    public class Stage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Purpose { get; set; }
        public string Goal { get; set; }
        public int Index { get; set; } // Allows sorting
        public int PhaseId { get; set; } // Parent reference
        public Phase Phase { get; set; }
        public List<WorkflowStep> Steps { get; set; } = new();
        public List<Metric> Metrics { get; set; } = new();
    }

    // Defines a step within a stage
    public class WorkflowStep
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Index { get; set; } // Allows sorting
        public int StageId { get; set; } // Parent reference
        public Stage Stage { get; set; }
        public List<Role> Roles { get; set; } = new();
        public List<Input> Inputs { get; set; } = new();
        public List<Notification> Notifications { get; set; } = new();
        public List<Meeting> Meetings { get; set; } = new();
        public List<Output> Outputs { get; set; } = new();
        public List<Event> Events { get; set; } = new();
        public List<EventHandler> EventHandlers { get; set; } = new();
        public List<AutomationHook> AutomationHooks { get; set; } = new();
    }
}

