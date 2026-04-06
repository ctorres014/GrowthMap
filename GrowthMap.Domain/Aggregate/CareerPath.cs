using GrowthMap.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrowthMap.Domain.Aggregate
{
    public class CareerPath: BaseAggregate
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public Guid TargetRoleId { get; set; }
        public Role TargetRole { get; set; } = null!;

        /// <summary>
        /// Score 0.0–1.0 calculado por el dominio y persistido.
        /// Se recalcula via background job al cambiar EmployeeSkill.
        /// Evita recalcular en cada request.
        /// </summary>
        public float ReadinessScore { get; set; } = 0f;

        public CareerPathStatus Status { get; set; } = CareerPathStatus.Draft;

        public DateTime? TargetDate { get; set; }

        // Navigation properties
        public ICollection<Milestone> Milestones { get; set; } = [];

        // Método de dominio para recalcular el score
        public void RecalculateReadiness(IEnumerable<EmployeeSkill> employeeSkills, IEnumerable<RoleSkill> roleSkills)
        {
            var roleSkillList = roleSkills.ToList();
            if (roleSkillList.Count == 0)
            {
                ReadinessScore = 0f;
                return;
            }

            var employeeSkillMap = employeeSkills.ToDictionary(es => es.SkillId, es => es.ProficiencyLevel);

            float totalWeight = 0f;
            float acquiredWeight = 0f;

            foreach (var rs in roleSkillList)
            {
                // Las skills Required pesan el doble que las Preferred
                float weight = rs.Importance == SkillImportance.Required ? 2f : 1f;
                totalWeight += weight;

                if (employeeSkillMap.TryGetValue(rs.SkillId, out int currentLevel))
                {
                    float ratio = Math.Min((float)currentLevel / rs.MinProficiency, 1f);
                    acquiredWeight += weight * ratio;
                }
            }

            ReadinessScore = totalWeight > 0 ? acquiredWeight / totalWeight : 0f;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
