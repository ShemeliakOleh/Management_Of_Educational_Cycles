using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
    public class Teacher : BaseEntity
    {
        [Display(Name = "Ім'я")]
        public string Name { get; set; }
        [Display(Name = "Прізвище")]
        public string Surname { get; set; }
        [Display(Name = "Кафедра")]
        public Department Department { get; set; }
        public Guid? DepartmentId { get; set; }
        public List<WorkManagementCycle> WorkManagementCycles { get; set; }
        public List<EducationalCycle> EducationalCycles { get; set; }
    }
}
