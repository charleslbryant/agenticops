using System;
using System.Collections.Generic;
using AgenticOps.Domain.Common;

namespace AgenticOps.Domain.ValueDelivery
{
    public class Stage : BaseEntity
    {
        public string Name { get; private set; }
        public string Purpose { get; private set; }
        public string Goal { get; private set; }
        public int Index { get; private set; }
        public int PhaseId { get; private set; }
        public Phase Phase { get; private set; }
        private readonly List<WorkflowStep> _steps = new();
        public IReadOnlyCollection<WorkflowStep> Steps => _steps.AsReadOnly();

        private Stage() : base() { } // For EF Core

        public Stage(string name, string purpose, string goal, int index, Phase phase) : base()
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Stage name cannot be empty", nameof(name));
            if (string.IsNullOrWhiteSpace(purpose))
                throw new ArgumentException("Stage purpose cannot be empty", nameof(purpose));
            if (string.IsNullOrWhiteSpace(goal))
                throw new ArgumentException("Stage goal cannot be empty", nameof(goal));

            Name = name;
            Purpose = purpose;
            Goal = goal;
            Index = index;
            Phase = phase ?? throw new ArgumentNullException(nameof(phase));
            PhaseId = phase.Id;
        }

        public void AddStep(WorkflowStep step)
        {
            _steps.Add(step ?? throw new ArgumentNullException(nameof(step)));
        }
    }
}
