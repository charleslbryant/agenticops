using System;
using AgenticOps.Domain.Common;

namespace AgenticOps.Domain.ValueDelivery.Components
{
    public class Meeting : BaseEntity
    {
        public string Name { get; private set; }

        private Meeting() : base() { } // For EF Core

        public Meeting(string name) : base()
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Meeting name cannot be empty", nameof(name));

            Name = name;
        }
    }
}
