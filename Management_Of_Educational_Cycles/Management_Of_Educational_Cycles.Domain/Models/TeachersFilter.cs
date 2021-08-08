using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Management_Of_Educational_Cycles.Domain.Models
{
    public class TeachersFilter
    {
        [Display(Name = "Ім'я")]
        public string TeacherName { get; set; }
        [Display(Name = "Прізвище")]
        public string TeacherSurname { get; set; }
        [Display(Name = "Факультет")]
        public string SelectedFaculty { get; set; }
        public IEnumerable<SelectListItem> Faculties { get; set; }

        [Display(Name = "Кафедра")]
        public string SelectedDepartment { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }

        public List<Teacher> Teachers { get; set; }
        public TeachersFilter()
        {
            this.TeacherName = "";
            this.TeacherSurname = "";
        }

    }
}
