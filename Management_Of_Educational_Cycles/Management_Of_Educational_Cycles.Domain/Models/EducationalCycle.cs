using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
   public enum TypeOfClasses
    {
        Lecture,
        Laboratory,
        Seminar
    }
    public class EducationalCycle : BaseEntity
    {
        public string Name { get; set; }
        public Guid? GroupId { get; set; }
        public AcademicGroup Group { get; set; }
        public Guid? DisciplineId { get; set; }
        public Department Department { get; set; }
        public Guid? DepartmentId { get; set; }
        public Discipline Discipline { get; set; }
        public Guid? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public TypeOfClasses TypeOfClasses { get; set; }
        public int NumberOfHours { get; set; }
        public int Semester { get; set; }


    }
}
