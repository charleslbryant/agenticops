using System;
using AgenticOps.Domain.Common;

namespace AgenticOps.Domain.ValueDelivery.Components
{
    public class Input : BaseEntity
    {
        public string Name { get; private set; }
        public string Source { get; private set; }

        private Input() : base() { } // For EF Core

        public Input(string name, string source) : base()
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Input name cannot be empty", nameof(name));

            Name = name;
            Source = source;
        }
    }
}
