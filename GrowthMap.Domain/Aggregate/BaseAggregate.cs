using System;
using System.Collections.Generic;
using System.Text;

namespace GrowthMap.Domain.Aggregate
{
    public class BaseAggregate
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
