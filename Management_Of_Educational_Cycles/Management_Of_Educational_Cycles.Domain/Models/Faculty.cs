using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
    public class Faculty : BaseEntity
    {
        [Display(Name = "Назва")]
        public string Name { get; set; }
        public List<Department> Departments { get; set; }

    }
}
