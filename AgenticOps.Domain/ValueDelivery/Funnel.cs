using System;
using System.Collections.Generic;
using AgenticOps.Domain.Common;

namespace AgenticOps.Domain.ValueDelivery
{
    public class Funnel : BaseEntity
    {
        public string Name { get; private set; }
        public int Index { get; private set; }
        private readonly List<Phase> _phases = new();
        public IReadOnlyCollection<Phase> Phases => _phases.AsReadOnly();

        private Funnel() : base() { } // For EF Core

        public Funnel(string name, int index) : base()
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Funnel name cannot be empty", nameof(name));
            
            Name = name;
            Index = index;
        }

        public void AddPhase(Phase phase)
        {
            _phases.Add(phase ?? throw new ArgumentNullException(nameof(phase)));
        }
    }
}
