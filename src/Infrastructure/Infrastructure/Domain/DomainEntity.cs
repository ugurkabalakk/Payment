using System;

namespace Infrastructure.Domain
{
    public abstract class DomainEntity : Entity
    {
        public DateTime? UpdatedDate { get; set; }
        public int? FailureReasonCode { get; set; }
    }
}