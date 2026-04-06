using System;
using System.Collections.Generic;
using System.Text;

namespace GrowthMap.Domain.Aggregate
{
    public class Skill
    {
        public string Name { get; set; } = string.Empty;

        // Categoría libre: "Backend", "Frontend", "DevOps", "Soft Skills", etc.
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        // Navigation properties
        public ICollection<RoleSkill> RoleSkills { get; set; } = [];
        public ICollection<EmployeeSkill> EmployeeSkills { get; set; } = [];
    }
}
