using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
    public class TeacherEditViewModel
    {
        [Display(Name = "Id")]
        public Guid? TeacherId { get; set; }

        [Display(Name = "Name")]
        public string TeacherName { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string TeacherSurname { get; set; }

        [Required]
        [Display(Name = "Faculty")]
        public string SelectedFaculty { get; set; }
        public List<SelectListItem> Faculties { get; set; }

        [Required]
        [Display(Name = "Department")]
        public string SelectedDepartment { get; set; }
        public List<SelectListItem> Departments { get; set; }

    }
}
