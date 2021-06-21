﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
    public class Group : BaseEntity, IGroup
    {
        public string Name { get; set; }
        public List<AcademicGroup> AcademicGroups { get; set; }
        
    }
}
