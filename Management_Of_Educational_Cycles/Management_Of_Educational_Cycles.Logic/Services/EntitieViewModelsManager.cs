using Management_Of_Educational_Cycles.Logic.Interfaces.IEntityViewModelProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Services
{
   public class EntitieViewModelsManager
    {
        public readonly IDepartmentViewsProvider departmentsProvider;
        public readonly IDisciplineViewsProvider disciplinesProvider;
        public readonly IEducationalCycleViewsProvider educationalCyclesProvider;
        public readonly IFacultyViewsProvider facultiesProvider;
        public readonly IGroupViewsProvider groupsProvider;
        public readonly ITeacherViewsProvider teachersProvider;
        public readonly IWorkManagementCycleViewsProvider workManagementCyclesProvider;
        
        public EntitieViewModelsManager(IDepartmentViewsProvider departmentsProvider, IDisciplineViewsProvider disciplinesProvider,
            IEducationalCycleViewsProvider educationalCyclesProvider,IFacultyViewsProvider facultiesProvider,
            IGroupViewsProvider groupsProvider, ITeacherViewsProvider teachersProvider,
            IWorkManagementCycleViewsProvider workManagementCyclesProvider)
        {
            this.departmentsProvider = departmentsProvider;
            this.disciplinesProvider = disciplinesProvider;
            this.educationalCyclesProvider = educationalCyclesProvider;
            this.facultiesProvider = facultiesProvider;
            this.groupsProvider = groupsProvider;
            this.teachersProvider = teachersProvider;
            this.workManagementCyclesProvider = workManagementCyclesProvider;
        }
        
    }
}
