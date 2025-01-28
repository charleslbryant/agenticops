using System;
using AgenticOps.Domain.Common;

namespace AgenticOps.Domain.ValueDelivery.Components
{
    public class Event : BaseEntity
    {
        public string Type { get; private set; }
        public string Name { get; private set; }

        private Event() : base() { } // For EF Core

        public Event(string type, string name) : base()
        {
            if (string.IsNullOrWhiteSpace(type))
                throw new ArgumentException("Event type cannot be empty", nameof(type));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Event name cannot be empty", nameof(name));

            Type = type;
            Name = name;
        }
    }
}
