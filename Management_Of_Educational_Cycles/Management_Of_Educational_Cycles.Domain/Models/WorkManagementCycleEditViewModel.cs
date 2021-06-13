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
        public Guid? CycleId { get; set; }

        [Display(Name = "Name")]
        public string CycleName { get; set; }


        [Display(Name = "Number of hours")]
        public int NumberOfHours { get; set; }

        [Display(Name = "Semester")]
        public int Semester { get; set; }

        [Required]
        [Display(Name = "Faculty")]
        public string SelectedFaculty { get; set; }
        public IEnumerable<SelectListItem> Faculties { get; set; }

        [Required]
        [Display(Name = "Department")]
        public string SelectedDepartment { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }

        [Required]
        [Display(Name = "Group")]
        public string SelectedGroup { get; set; }
        public IEnumerable<SelectListItem> Groups { get; set; }
    }
}
