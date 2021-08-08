using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
   public class FacultiesFilter
    {
        [Display (Name ="Назва")]
        public string FacultyName { get; set; }
        public List<Faculty> Faculties { get; set; }
        public FacultiesFilter()
        {
            Faculties = new List<Faculty>();
        }
    }
}
