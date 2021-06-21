using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
   public class MixedGroupEditViewModel
    {
        [Display(Name = "Name")]
        public string GroupId { get; set; }

        [Display(Name = "Name")]
        public string GroupName { get; set; }

        [Display(Name = "Faculty")]
        public string SelectedFaculty { get; set; }
        public IEnumerable<SelectListItem> Faculties { get; set; }

        [Display(Name = "Department")]
        public string SelectedDepartment { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }

        [Display(Name = "Group")]
        public string SelectedGroup { get; set; }
        public IEnumerable<SelectListItem> Groups { get; set; }

        [Required]
        [Display(Name = "Selected Groups")]
        public List<AcademicGroup> SelectedGroups { get; set; }
    }
}
