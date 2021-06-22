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
        [Display(Name = "Discipline")]
        public string DisciplineName { get; set; }

        [Display(Name = "Number of lecturers hours")]
        public int LectureHours { get; set; }

        [Display(Name = "Number of laborators hours")]
        public int LaboratorHours { get; set; }

        [Display(Name = " Number of seminars hours")]
        public int SeminarHours { get; set; }

        [Display(Name = "Total number")]
        public int TotalHours {
            get { return LectureHours + LaboratorHours + SeminarHours; } 
        }
        public DisciplineViewModel()
        {
            LectureHours = 0;
            LaboratorHours = 0;
            SeminarHours = 0;
        }
      
    }
}
