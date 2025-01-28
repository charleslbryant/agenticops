using System;
using AgenticOps.Domain.Common;

namespace AgenticOps.Domain.ValueDelivery.Components
{
    public class Notification : BaseEntity
    {
        public string Notice { get; private set; }
        public string Recipients { get; private set; }

        private Notification() : base() { } // For EF Core

        public Notification(string notice, string recipients) : base()
        {
            if (string.IsNullOrWhiteSpace(notice))
                throw new ArgumentException("Notice cannot be empty", nameof(notice));
            if (string.IsNullOrWhiteSpace(recipients))
                throw new ArgumentException("Recipients cannot be empty", nameof(recipients));

            Notice = notice;
            Recipients = recipients;
        }
    }
}
