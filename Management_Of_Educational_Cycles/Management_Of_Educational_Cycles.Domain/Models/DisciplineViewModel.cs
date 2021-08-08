using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
   public class DisciplineViewModel
    {
        [Display(Name = "Дисципліна")]
        public string DisciplineName { get; set; }

        [Display(Name = "Кількість лекційних годин")]
        public int LectureHours { get; set; }

        [Display(Name = "Кількість лабораторних годин")]
        public int LaboratorHours { get; set; }

        [Display(Name = "Кількість семінарських годин")]
        public int SeminarHours { get; set; }
        [Display(Name = "Група")]
        public AcademicGroup Group { get; set; }

        [Display(Name = "Загальна кількість годин")]
        public int TotalHours { get; set; }
        public DisciplineViewModel()
        {
            LectureHours = 0;
            LaboratorHours = 0;
            SeminarHours = 0;
        }
      
    }
}
