using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
    public class EducationalCycle : BaseEntity
    {
        public string Name { get; set; }
        public Group Group { get; set; }
        public Discipline Discipline { get; set; }
        public Teacher Teacher { get; set; }
        public string TypeOfClasses { get; set; }
        public int NumberOfHours { get; set; }
        public int Semester { get; set; }


    }
}
