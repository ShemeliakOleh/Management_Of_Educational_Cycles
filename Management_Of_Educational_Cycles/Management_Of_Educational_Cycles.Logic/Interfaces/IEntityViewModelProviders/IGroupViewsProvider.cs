using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Interfaces.IEntityViewModelProviders
{
    public interface IGroupViewsProvider
    {
        public Task<GroupsFilter> CreateGroupsFilter();
        public Task<bool> SaveAcademicGroup(AcademicGroupEditViewModel academicGroupEditViewModel);
        public Task<MixedGroupEditViewModel> CreateMixedGroup();
        public Task<AcademicGroupEditViewModel> CreateAcademicGroupEditViewModel(AcademicGroup group);
        public Task<AcademicGroupEditViewModel> CreateAcademicGroup();
        public Task<bool> UpdateAcademicGroup(AcademicGroupEditViewModel groupToUpdate);
        public Task<List<SelectListItem>> GetGroupsByDepartment(Guid? departmentId);
        public Task<bool> SaveMixedGroup(MixedGroupEditViewModel mixedGroupEditViewModel);
    }
}
