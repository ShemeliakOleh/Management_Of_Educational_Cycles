using Management_Of_Educational_Cycles.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Interfaces.IEntityRepository
{
    public interface IWorkManagementCyclesRepository
    {
        public Task<WorkManagementCycle> GetById(Guid? id);
        public Task<List<WorkManagementCycle>> GetWorkManagementCycles();
        public Task<bool> CreateWorkManagementCycle(WorkManagementCycle workManagementCycle);
        public Task<bool> UpdateWorkManagementCycle(WorkManagementCycle workManagementCycle);
        public Task<bool> DeleteById(Guid? id);
        public Task<List<WorkManagementCycle>> GetFilteredWorkManagementCycles(WorkManagementCycle pattern);
    }
}
