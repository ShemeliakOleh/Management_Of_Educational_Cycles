using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
    public class DepartmentEditViewModel
    {
        [Display(Name = "Department Id")]
        public string DepartmentId { get; set; }

        [Display(Name = "Name")]
        public string DepartmentName { get; set; }

        [Required]
        [Display(Name = "Faculty")]
        public string SelectedFaculty { get; set; }
        public IEnumerable<SelectListItem> Faculties { get; set; }
    }
}
