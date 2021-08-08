using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
   public class Department : BaseEntity
    {
        [Display(Name = "Назва")]
        public string Name { get; set; }
        public List<AcademicGroup> Groups { get; set; }
        public List<Teacher> Teachers { get; set; }
        public Guid? FacultyId { get; set; }
        [Display(Name = "Факультет")]
        public Faculty Faculty { get; set; }

    }
}
