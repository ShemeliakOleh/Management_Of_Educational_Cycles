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
    public class WorkManagementCyclesRepository : EntityRepository,IWorkManagementCyclesRepository
    {
        public WorkManagementCyclesRepository(IRequestSender requestSender) : base(requestSender)
        {

        }
        public Task<bool> CreateWorkManagementCycle(WorkManagementCycle workManagementCycle)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<WorkManagementCycle> GetById(Guid? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<WorkManagementCycle>> GetFilteredWorkManagementCycles(WorkManagementCycle pattern)
        {
            throw new NotImplementedException();
        }

        public Task<List<WorkManagementCycle>> GetWorkManagementCycles()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateWorkManagementCycle(WorkManagementCycle workManagementCycle)
        {
            throw new NotImplementedException();
        }
    }
}
