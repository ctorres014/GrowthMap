using GrowthMap.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrowthMap.Domain.Aggregate
{
    public class Milestone: BaseAggregate
    {
        public Guid CareerPathId { get; set; }
        public CareerPath CareerPath { get; set; } = null!;

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public MilestoneType Type { get; set; }
        public MilestoneStatus Status { get; set; } = MilestoneStatus.Pending;

        public DateTime? DueDate { get; set; }
        public DateTime? CompletedAt { get; set; }

        // Método de dominio: completa el hito y registra la fecha
        public void Complete()
        {
            Status = MilestoneStatus.Completed;
            CompletedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Skip()
        {
            Status = MilestoneStatus.Skipped;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
