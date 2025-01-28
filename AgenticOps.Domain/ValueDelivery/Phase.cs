using System;
using System.Collections.Generic;
using AgenticOps.Domain.Common;

namespace AgenticOps.Domain.ValueDelivery
{
    public class Phase : BaseEntity
    {
        public string Name { get; private set; }
        public int Index { get; private set; }
        public int FunnelId { get; private set; }
        public Funnel Funnel { get; private set; }
        private readonly List<Stage> _stages = new();
        public IReadOnlyCollection<Stage> Stages => _stages.AsReadOnly();

        private Phase() : base() { } // For EF Core

        public Phase(string name, int index, Funnel funnel) : base()
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Phase name cannot be empty", nameof(name));
            
            Name = name;
            Index = index;
            Funnel = funnel ?? throw new ArgumentNullException(nameof(funnel));
            FunnelId = funnel.Id;
        }

        public void AddStage(Stage stage)
        {
            _stages.Add(stage ?? throw new ArgumentNullException(nameof(stage)));
        }
    }
}
