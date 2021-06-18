using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
   public class Department : BaseEntity
    {
        
        public string Name { get; set; }
        public List<Group> Groups { get; set; }
        public List<Teacher> Teachers { get; set; }
        public Guid? FacultyId { get; set; }
        public Faculty Faculty { get; set; }

    }
}
