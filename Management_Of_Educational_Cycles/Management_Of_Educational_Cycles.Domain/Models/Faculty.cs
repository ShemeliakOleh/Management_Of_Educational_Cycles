using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
    public class Faculty : BaseEntity
    {
        public string Name { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
        public List<Discipline> Disciplines { get; set; } = new List<Discipline>();

    }
}
