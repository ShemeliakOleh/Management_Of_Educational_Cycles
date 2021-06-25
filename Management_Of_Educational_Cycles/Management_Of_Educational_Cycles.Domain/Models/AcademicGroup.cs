﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
    public class AcademicGroup : BaseEntity, IGroup
    {
        public string Name { get; set; }
        public Department Department { get; set; }
        public Guid? DepartmentId { get; set; }

        public int NumberOfStudents { get; set; }

    }
}

