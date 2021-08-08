using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
    public class WorkManagementCycleEditViewModel
    {
        [Display(Name = "Id")]
        public Guid? CycleId { get; set; }

        [Display(Name = "Назва")]
        public string CycleName { get; set; }


        [Display(Name = "Кількість годин")]
        public int NumberOfHours { get; set; }

        [Display(Name = "Семестр")]
        public int Semester { get; set; }

        [Required]
        [Display(Name = "Факультет")]
        public string SelectedFaculty { get; set; }
        public IEnumerable<SelectListItem> Faculties { get; set; }

        [Required]
        [Display(Name = "Кафедра")]
        public string SelectedDepartment { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }

        [Required]
        [Display(Name = "Група")]
        public string SelectedGroup { get; set; }
        public IEnumerable<SelectListItem> Groups { get; set; }
    }
}
