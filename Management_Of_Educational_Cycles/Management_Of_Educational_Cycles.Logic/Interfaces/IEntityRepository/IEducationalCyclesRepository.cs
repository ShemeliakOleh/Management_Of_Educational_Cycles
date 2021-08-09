using Management_Of_Educational_Cycles.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Interfaces.IEntityRepository
{
    public interface IEducationalCyclesRepository
    {
        public Task<EducationalCycle> GetById(Guid? id);
        public Task<List<EducationalCycle>> GetEducationalCycles();
        public Task<bool> CreateEducationalCycle(EducationalCycle educationalCycle);
        public Task<bool> UpdateEducationalCycle(EducationalCycle educationalCycle);
        public Task<bool> DeleteById(Guid? id);
        public Task<List<EducationalCycle>> GetFilteredEducationalCycles(EducationalCycle pattern);
        public Task<bool> AppointTeacherForCycle(Guid? educationalCycleId, Guid? teacherId);
        public Task<bool> ThrowOffTeacherForCycle(Guid? educationalCycleId, Guid? teacherId);
    }
}
