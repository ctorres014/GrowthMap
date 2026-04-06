using GrowthMap.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrowthMap.Domain.Aggregate
{
    public class Role
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public RoleLevel Level { get; set; }
        public RoleTrack Track { get; set; }
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public ICollection<RoleSkill> RequiredSkills { get; set; } = [];
        public ICollection<Employee> Employees { get; set; } = [];
        public ICollection<CareerPath> CareerPaths { get; set; } = [];
    }
}
