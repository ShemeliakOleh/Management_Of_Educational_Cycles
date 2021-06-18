using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
    public class Teacher : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public Department Department { get; set; }
        public Guid? DepartmentId { get; set; }
        public List<WorkManagementCycle> WorkManagementCycles { get; set; }
        public List<EducationalCycle> EducationalCycles { get; set; }
    }
}
