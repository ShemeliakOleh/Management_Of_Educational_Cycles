using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
   public class GroupsFilter
    {
        [Display (Name = "Назва")]
        public string GroupName { get; set; }
        [Display (Name = "Факультет")]
        public string SelectedFaculty { get; set; }
        public IEnumerable<SelectListItem> Faculties { get; set; }

        [Display(Name = "Кафедра")]
        public string SelectedDepartment { get; set; }
        public IEnumerable<SelectListItem> Departments { get; set; }
        public List<AcademicGroup> Groups { get; set; }
        public GroupsFilter()
        {
            GroupName = "";
        }
    }
}
