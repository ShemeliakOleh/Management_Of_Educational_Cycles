using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
   public enum TypeOfClasses
    {
        Лекційні,
        Лабораторні,
        Семінарські
    }
    public class EducationalCycle : BaseEntity
    {
        [Display(Name = "Назва")]
        public string Name { get; set; }
        public Guid? GroupId { get; set; }
        [Display(Name = "Група")]
        public AcademicGroup Group { get; set; }
        public Guid? DisciplineId { get; set; }
        [Display(Name = "Кафедра")]
        public Department Department { get; set; }
        public Guid? DepartmentId { get; set; }
        [Display(Name = "Дисципліна")]
        public Discipline Discipline { get; set; }
        public Guid? TeacherId { get; set; }
        [Display(Name = "Викладач")]
        public Teacher Teacher { get; set; }
        [Display(Name = "Тип занять")]
        public TypeOfClasses TypeOfClasses { get; set; }
        [Display(Name = "Кількість годин")]
        public int NumberOfHours { get; set; }
        [Display(Name = "Семестр")]
        public int Semester { get; set; }


    }
}
