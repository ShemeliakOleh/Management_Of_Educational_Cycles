using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Management_Of_Educational_Cycles.Domain.Models;
using Management_Of_Educational_Cycles.Logic.Interfaces;
using Management_Of_Educational_Cycles.Logic.Interfaces.IEntityRepository;

namespace Management_Of_Educational_Cycles.Logic.Services.EntityRepository
{
    public class EducationalCyclesRepository :EntityRepository ,IEducationalCyclesRepository
    {
        public EducationalCyclesRepository(IRequestSender requestSender) : base(requestSender)
        {

        }
        public Task<bool> CreateEducationalCycle(EducationalCycle educationalCycle)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<EducationalCycle> GetById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EducationalCycle>> GetEducationalCycles()
        {
            throw new NotImplementedException();
        }

        public Task<List<EducationalCycle>> GetFilteredEducationalCycles(EducationalCycle pattern)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateEducationalCycle(EducationalCycle educationalCycle)
        {
            throw new NotImplementedException();
        }
    }
}
