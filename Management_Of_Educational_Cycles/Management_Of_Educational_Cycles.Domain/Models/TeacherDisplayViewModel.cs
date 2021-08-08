using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
     public class TeacherDisplayViewModel
    {
        [Display(Name = "Teacher Id")]
        public Guid? TeacherId { get; set; }

        [Display(Name = "Ім'я")]
        public string TeacherName { get; set; }

        [Display(Name = "Прізвище")]
        public string TeacherSurname { get; set; }

        [Display(Name = "Факультет")]
        public string FacultyName { get; set; }

        [Display(Name = "Кафедра")]
        public string DepartmentName { get; set; }
        public List<DisciplineViewModel> FirstSemesterDisciplines { get; set; }
        public List<DisciplineViewModel> SecondSemesterDisciplines { get; set; }




    }
}
