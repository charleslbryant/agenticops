using System;

namespace AgenticOps.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public string CreatedBy { get; protected set; }
        public DateTime? LastUpdatedDate { get; protected set; }
        public string LastUpdatedBy { get; protected set; }

        protected BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
        }

        public void SetCreatedBy(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("User ID cannot be empty", nameof(userId));

            CreatedBy = userId;
        }

        public void SetLastUpdatedBy(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                throw new ArgumentException("User ID cannot be empty", nameof(userId));

            LastUpdatedBy = userId;
            LastUpdatedDate = DateTime.UtcNow;
        }
    }
}
