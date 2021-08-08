using Management_Of_Educational_Cycles.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Interfaces.IEntityViewModelProviders
{
    public interface IWorkManagementCycleViewsProvider
    {
        public Task<bool> SaveWorkManagementCycle(WorkManagementCycleEditViewModel cycleToSave);
        public Task<bool> UpdateWorkManagementCycle(WorkManagementCycleEditViewModel cycleToUpdate);
        public Task<WorkManagementCycleEditViewModel> CreateWorkMangementCycle(WorkManagementCycle workManagementCycle);
        public Task<WorkManagementCycleEditViewModel> CreateWorkMangementCycle();
        public Task<bool> AppointTeacherForCycle(Guid? workManagementCycleId, Guid? teacherId);
        public Task<bool> ThrowOffTeacherForCycle(Guid? workManagementCycleId, Guid? teacherId);
    }
}
