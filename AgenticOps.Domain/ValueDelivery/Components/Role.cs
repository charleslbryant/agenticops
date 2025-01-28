using System;
using AgenticOps.Domain.Common;

namespace AgenticOps.Domain.ValueDelivery.Components
{
    public class Role : BaseEntity
    {
        public string Title { get; private set; }
        public string Responsibilities { get; private set; }

        private Role() : base() { } // For EF Core

        public Role(string title, string responsibilities) : base()
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Role title cannot be empty", nameof(title));
            if (string.IsNullOrWhiteSpace(responsibilities))
                throw new ArgumentException("Role responsibilities cannot be empty", nameof(responsibilities));

            Title = title;
            Responsibilities = responsibilities;
        }
    }
}
