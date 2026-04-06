using GrowthMap.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrowthMap.Domain.Aggregate
{
    /// <summary>
    /// Tabla de unión rica entre Role y Skill.
    /// Define qué skills requiere un rol, con qué importancia y nivel mínimo esperado.
    /// </summary>
    public class RoleSkill
    {
        public Guid RoleId { get; set; }
        public Role Role { get; set; } = null!;

        public Guid SkillId { get; set; }
        public Skill Skill { get; set; } = null!;

        public SkillImportance Importance { get; set; } = SkillImportance.Required;

        /// <summary>
        /// Nivel mínimo de proficiencia esperado: escala 1–5.
        /// 1 = awareness, 2 = básico, 3 = independiente, 4 = avanzado, 5 = referente.
        /// </summary>
        public int MinProficiency { get; set; } = 3;
    }
}
