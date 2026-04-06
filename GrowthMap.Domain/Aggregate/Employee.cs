using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace GrowthMap.Domain.Aggregate
{
    public class Employee: BaseAggregate
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public DateTime HireDate { get; set; }

        // Self-referencing FK — nullable: un empleado puede no tener manager registrado
        public Guid? ManagerId { get; set; }
        public Employee? Manager { get; set; }

        // Rol actual del empleado en la organización
        public Guid? CurrentRoleId { get; set; }
        public Role? CurrentRole { get; set; }

        // Navigation properties
        public ICollection<EmployeeSkill> Skills { get; set; } = [];
        public ICollection<CareerPath> CareerPaths { get; set; } = [];
        public ICollection<Employee> DirectReports { get; set; } = [];
    }
}
