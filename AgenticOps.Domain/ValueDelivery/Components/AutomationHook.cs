using System;
using AgenticOps.Domain.Common;

namespace AgenticOps.Domain.ValueDelivery.Components
{
    public class AutomationHook : BaseEntity
    {
        public string System { get; private set; }
        public string ApiCall { get; private set; }

        private AutomationHook() : base() { } // For EF Core

        public AutomationHook(string system, string apiCall) : base()
        {
            if (string.IsNullOrWhiteSpace(system))
                throw new ArgumentException("System cannot be empty", nameof(system));
            if (string.IsNullOrWhiteSpace(apiCall))
                throw new ArgumentException("API call cannot be empty", nameof(apiCall));

            System = system;
            ApiCall = apiCall;
        }
    }
}
