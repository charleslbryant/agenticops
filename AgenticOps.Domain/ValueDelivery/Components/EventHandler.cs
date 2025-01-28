using System;
using AgenticOps.Domain.Common;

namespace AgenticOps.Domain.ValueDelivery.Components
{
    public class WorkflowEventHandler : BaseEntity
    {
        public string Event { get; private set; }
        public string Condition { get; private set; }
        public string Action { get; private set; }

        private WorkflowEventHandler() : base() { } // For EF Core

        public WorkflowEventHandler(string @event, string condition, string action) : base()
        {
            if (string.IsNullOrWhiteSpace(@event))
                throw new ArgumentException("Event cannot be empty", nameof(@event));
            if (string.IsNullOrWhiteSpace(action))
                throw new ArgumentException("Action cannot be empty", nameof(action));

            Event = @event;
            Condition = condition;
            Action = action;
        }
    }
}
