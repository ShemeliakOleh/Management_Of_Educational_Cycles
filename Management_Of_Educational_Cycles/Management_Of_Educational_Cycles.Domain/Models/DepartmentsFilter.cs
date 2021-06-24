using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
   public class DepartmentsFilter
    {
        [Display(Name = "Name")]
        public string DepartmentName { get; set; }
        [Display(Name = "Faculty")]
        public string SelectedFaculty { get; set; }
        public IEnumerable<SelectListItem> Faculties { get; set; }
        public List<Department> Departments { get; set; }

        public DepartmentsFilter()
        {
            DepartmentName = "";
        }
    }
}
