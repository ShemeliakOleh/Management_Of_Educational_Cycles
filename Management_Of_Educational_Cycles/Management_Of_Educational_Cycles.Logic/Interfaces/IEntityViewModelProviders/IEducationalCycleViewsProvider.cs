using Management_Of_Educational_Cycles.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Interfaces.IEntityViewModelProviders
{
    public interface IEducationalCycleViewsProvider
    {
        public EducationalCycleEditViewModel CreateEducationalCycleEditViewModel();
        public Task<bool> SaveEducationalCycle(EducationalCycleEditViewModel cycleToSave);
        public Task<EducationalCycleEditViewModel> CreateEducationalCycle(EducationalCycle educationalCycle);
        public Task<bool> UpdateEducationalCycle(EducationalCycleEditViewModel cycleToUpdate);
        
    }
}
