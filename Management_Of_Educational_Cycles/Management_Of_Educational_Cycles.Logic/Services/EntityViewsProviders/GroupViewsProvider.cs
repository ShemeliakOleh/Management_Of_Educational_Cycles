using Management_Of_Educational_Cycles.Domain.Models;
using Management_Of_Educational_Cycles.Logic.Interfaces;
using Management_Of_Educational_Cycles.Logic.Interfaces.IEntityViewModelProviders;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Services.EntityViewsProviders
{


    public class GroupViewsProvider :EntityProvider,IGroupViewsProvider
    {
        public GroupViewsProvider(DataManager dataManager) : base(dataManager)
        {

        }
        public async Task<AcademicGroupEditViewModel> CreateAcademicGroup()
        {
            var group = new AcademicGroupEditViewModel()
            {
                Faculties = await GetAllFaculties(),
                Departments = new List<SelectListItem>()
            };
            return group;
        }
        public async new Task<List<SelectListItem>> GetGroupsByDepartment(Guid? departmentId)
        {
            return await base.GetGroupsByDepartment(departmentId);
        }
        
        public async Task<bool> SaveAcademicGroup(AcademicGroupEditViewModel groupToSave)
        {
            if (groupToSave != null)
            {

                var group = new AcademicGroup()
                {
                    Name = groupToSave.GroupName,
                    NumberOfStudents = groupToSave.NumberOfStudents,
                    DepartmentId = Guid.Parse(groupToSave.SelectedDepartment)

                };
                
                var response = await dataManager.groupsRepository.CreateGroup(group);
                return true;
            }
            return false;
        }
        public async Task<AcademicGroupEditViewModel> CreateAcademicGroupEditViewModel(AcademicGroup group)
        {
            var groupEditViewModel = new AcademicGroupEditViewModel()
            {
                GroupName = group.Name,
                GroupId = group.Id.ToString(),
                Faculties = await GetAllFaculties(),
                SelectedDepartment = group.DepartmentId.ToString()

            };
            if (group.Department != null && group.Department.FacultyId != null)
            {
                groupEditViewModel.Departments = await GetDepartmentsByFaculty(group.Department.FacultyId);
                groupEditViewModel.SelectedFaculty = group.Department.FacultyId.ToString();
            }

            return groupEditViewModel;
        }
        public async Task<bool> UpdateAcademicGroup(AcademicGroupEditViewModel groupToUpdate)
        {
            if (groupToUpdate != null)
            {

                var group = new AcademicGroup()
                {
                    Id = Guid.Parse(groupToUpdate.GroupId),
                    Name = groupToUpdate.GroupName,
                    NumberOfStudents = groupToUpdate.NumberOfStudents,
                    DepartmentId = Guid.Parse(groupToUpdate.SelectedDepartment)
                };
                var response = await dataManager.groupsRepository.UpdateGroup(group);
                return true;
            }

            return false;
        }
        public async Task<MixedGroupEditViewModel> CreateMixedGroup()
        {
            MixedGroupEditViewModel mixedGroupEditViewModel = new MixedGroupEditViewModel()
            {
                Faculties = await GetAllFaculties(),
                Departments = new List<SelectListItem>(),
                Groups = new List<SelectListItem>()
            };
            return mixedGroupEditViewModel;
        }
        
        
        public async Task<GroupsFilter> CreateGroupsFilter()
        {
            GroupsFilter groupsFilter = new GroupsFilter()
            {
                GroupName = "",
                Faculties = await GetAllFaculties(),
                Departments = new List<SelectListItem>(),
                Groups = await dataManager.groupsRepository.GetAllGroups()

            };
            return groupsFilter;
        }

        public Task<bool> SaveMixedGroup(MixedGroupEditViewModel mixedGroupEditViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
