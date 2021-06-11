﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public Faculty Faculty { get; set; }
        public Guid? FacultyId { get; set; }
        public Department Department { get; set; }
        public Guid? DepartmentId { get; set; }
    }
}
