using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
    public class WorkManagementCycle
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Group Group { get; set; }
        public List<Teacher> Teachers { get; set; }
        public int NumberOfHours { get; set; }
        public int Semester { get; set; }
        public WorkManagementCycle()
        {
            Id = Guid.NewGuid();
        }
    }
}
