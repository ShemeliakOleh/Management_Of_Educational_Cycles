using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
   public class AcademicGroupEditViewModel
    {
        [Display(Name = "Id")]
        public string GroupId { get; set; }

        [Display(Name = "Назва")]
        public string GroupName { get; set; }

        [Display(Name = "Кількість студентів")]
        public int NumberOfStudents { get; set; }

        [Required]
        [Display(Name = "Факультет")]
        public string SelectedFaculty { get; set; }
        public List<SelectListItem> Faculties { get; set; }

        [Required]
        [Display(Name = "Кафедра")]
        public string SelectedDepartment { get; set; }
        public List<SelectListItem> Departments { get; set; }

    }
}
