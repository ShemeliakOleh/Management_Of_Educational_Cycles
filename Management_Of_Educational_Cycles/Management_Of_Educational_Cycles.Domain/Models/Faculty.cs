using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Models
{
    public class Faculty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Faculty()
        {
            Id = Guid.NewGuid();
        }
    }
}
