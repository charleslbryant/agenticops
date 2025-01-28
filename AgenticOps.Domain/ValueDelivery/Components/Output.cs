using System;
using AgenticOps.Domain.Common;

namespace AgenticOps.Domain.ValueDelivery.Components
{
    public class Output : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private Output() : base() { } // For EF Core

        public Output(string name, string description) : base()
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Output name cannot be empty", nameof(name));

            Name = name;
            Description = description;
        }
    }
}
