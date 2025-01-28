using System;
using System.Collections.Generic;
using AgenticOps.Domain.Common;
using AgenticOps.Domain.ValueDelivery.Components;

namespace AgenticOps.Domain.ValueDelivery
{
    public class WorkflowStep : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Index { get; private set; }
        public int StageId { get; private set; }
        public Stage Stage { get; private set; }

        private readonly List<Role> _roles = new();
        private readonly List<Input> _inputs = new();
        private readonly List<Notification> _notifications = new();
        private readonly List<Meeting> _meetings = new();
        private readonly List<Output> _outputs = new();
        private readonly List<Event> _events = new();
        private readonly List<WorkflowEventHandler> _eventHandlers = new();
        private readonly List<AutomationHook> _automationHooks = new();

        public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();
        public IReadOnlyCollection<Input> Inputs => _inputs.AsReadOnly();
        public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();
        public IReadOnlyCollection<Meeting> Meetings => _meetings.AsReadOnly();
        public IReadOnlyCollection<Output> Outputs => _outputs.AsReadOnly();
        public IReadOnlyCollection<Event> Events => _events.AsReadOnly();
        public IReadOnlyCollection<WorkflowEventHandler> EventHandlers => _eventHandlers.AsReadOnly();
        public IReadOnlyCollection<AutomationHook> AutomationHooks => _automationHooks.AsReadOnly();

        private WorkflowStep() : base() { } // For EF Core

        public WorkflowStep(string name, string description, int index, Stage stage) : base()
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("WorkflowStep name cannot be empty", nameof(name));
            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("WorkflowStep description cannot be empty", nameof(description));

            Name = name;
            Description = description;
            Index = index;
            Stage = stage ?? throw new ArgumentNullException(nameof(stage));
            StageId = stage.Id;
        }

        public void AddRole(Role role) => _roles.Add(role ?? throw new ArgumentNullException(nameof(role)));
        public void AddInput(Input input) => _inputs.Add(input ?? throw new ArgumentNullException(nameof(input)));
        public void AddNotification(Notification notification) => _notifications.Add(notification ?? throw new ArgumentNullException(nameof(notification)));
        public void AddMeeting(Meeting meeting) => _meetings.Add(meeting ?? throw new ArgumentNullException(nameof(meeting)));
        public void AddOutput(Output output) => _outputs.Add(output ?? throw new ArgumentNullException(nameof(output)));
        public void AddEvent(Event @event) => _events.Add(@event ?? throw new ArgumentNullException(nameof(@event)));
        public void AddEventHandler(WorkflowEventHandler handler) => _eventHandlers.Add(handler ?? throw new ArgumentNullException(nameof(handler)));
        public void AddAutomationHook(AutomationHook hook) => _automationHooks.Add(hook ?? throw new ArgumentNullException(nameof(hook)));
    }
}
