using System;
using System.Collections.Generic;
using System.Text;

namespace GrowthMap.Domain.Aggregate
{
    /// <summary>
    /// Registro del nivel de proficiencia de un empleado en una skill específica.
    /// Se actualiza en cada autoevaluación o validación del manager.
    /// </summary>
    public class EmployeeSkill
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;

        public Guid SkillId { get; set; }
        public Skill Skill { get; set; } = null!;

        /// <summary>
        /// Nivel actual del empleado: escala 1–5.
        /// Check constraint en la base de datos: BETWEEN 1 AND 5.
        /// </summary>
        public int ProficiencyLevel { get; set; }

        public DateTime LastAssessedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Justificación del nivel asignado: proyectos, certificaciones, etc.
        /// Requerido para niveles 4 y 5.
        /// </summary>
        public string? EvidenceNote { get; set; }
    }
}
