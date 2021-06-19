using Management_Of_Educational_Cycles.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Domain.Entities.Repository
{
   public interface IAcademicGroupRepository
    {
        public Task<bool> Add(AcademicGroup group);
        public Task<bool> Update(AcademicGroup group);
        public Task<bool> Remove(Guid? id);
        public Task<AcademicGroup> GetById(Guid? id);
        public Task<List<AcademicGroup>> GetAll();
        public bool Exists(Guid? id);
    }
}
