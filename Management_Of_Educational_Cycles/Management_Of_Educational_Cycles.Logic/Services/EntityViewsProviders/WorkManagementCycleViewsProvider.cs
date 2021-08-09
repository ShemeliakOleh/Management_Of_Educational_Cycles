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
    public class WorkManagementCycleViewsProvider :EntityProvider,IWorkManagementCycleViewsProvider
    {
        public WorkManagementCycleViewsProvider(DataManager dataManager) : base(dataManager)
        {

        }
        public async Task<bool> SaveWorkManagementCycle(WorkManagementCycleEditViewModel cycleToSave)
        {
            if (cycleToSave != null)
            {

                var workManagementCycle = new WorkManagementCycle()
                {
                    Name = cycleToSave.CycleName,
                    Semester = cycleToSave.Semester,
                    NumberOfHours = cycleToSave.NumberOfHours,
                    GroupId = Guid.Parse(cycleToSave.SelectedGroup),
                    DepartmentId = Guid.Parse(cycleToSave.SelectedDepartment)
                };
                var response = await dataManager.workManagementCyclesRepository.CreateWorkManagementCycle(workManagementCycle);
                return true;
            }

            return false;
        }
        public async Task<WorkManagementCycleEditViewModel> CreateWorkMangementCycle()
        {
            var cycle = new WorkManagementCycleEditViewModel()
            {
                Faculties = await GetAllFaculties(),
                Departments = new List<SelectListItem>(),
                Groups = new List<SelectListItem>()
            };
            return cycle;
        }
        public async Task<WorkManagementCycleEditViewModel> CreateWorkMangementCycle(WorkManagementCycle workManagementCycle)
        {
            var cycle = new WorkManagementCycleEditViewModel()
            {
                CycleName = workManagementCycle.Name,
                NumberOfHours = workManagementCycle.NumberOfHours,
                Semester = workManagementCycle.Semester,
                CycleId = workManagementCycle.Id,
                Faculties = await GetAllFaculties()
            };
            if (workManagementCycle.Group != null)
            {
                cycle.SelectedGroup = workManagementCycle.GroupId.ToString();
                if (workManagementCycle.Department != null)
                {
                    cycle.Groups = await GetGroupsByDepartment(workManagementCycle.DepartmentId);
                    cycle.SelectedDepartment = workManagementCycle.DepartmentId.ToString();
                    if (workManagementCycle.Department.FacultyId != null)
                    {
                        cycle.SelectedFaculty = workManagementCycle.Department.FacultyId.ToString();
                        cycle.Departments = await GetDepartmentsByFaculty(workManagementCycle.Department.FacultyId);
                    }
                }
            }
            return cycle;
        }
        public async Task<bool> UpdateWorkManagementCycle(WorkManagementCycleEditViewModel cycleToUpdate)
        {
            if (cycleToUpdate != null)
            {

                var workManagementCycle = new WorkManagementCycle()
                {
                    Id = cycleToUpdate.CycleId,
                    Name = cycleToUpdate.CycleName,
                    Semester = cycleToUpdate.Semester,
                    NumberOfHours = cycleToUpdate.NumberOfHours,
                    GroupId = Guid.Parse(cycleToUpdate.SelectedGroup)
                };
                var response = await dataManager.workManagementCyclesRepository.UpdateWorkManagementCycle(workManagementCycle);
                return true;
            }
            
            return false;
        }
       
    }
}
