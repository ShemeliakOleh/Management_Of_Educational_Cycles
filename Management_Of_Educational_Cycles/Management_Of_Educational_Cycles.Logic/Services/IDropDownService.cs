using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Services
{
    public interface IDropDownService
    {
        public Task<IEnumerable<SelectListItem>> GetFaculties();
        public Task<IEnumerable<SelectListItem>> GetDepartments(Guid? facultyId);
        public Task<IEnumerable<SelectListItem>> GetGroups(Guid? departmentId);
        public IEnumerable<SelectListItem> GetDepartments();
        public IEnumerable<SelectListItem> GetGroups();
        public Task<bool> SaveTeacher(TeacherEditViewModel teacherToSave);
        public Task<bool> SaveWorkManagementCycle(WorkManagementCycleEditViewModel cycleToSave);
        public Task<bool> UpdateWorkManagementCycle(WorkManagementCycleEditViewModel cycleToUpdate);
        public Task<bool> SaveGroup(GroupEditViewModel groupToSave);
        public Task<bool> SaveDepartment(DepartmentEditViewModel departmentToSave);
        public Task<EducationalCycleEditViewModel> CreateEducationalCycle();
        public  Task<List<TeacherDisplayViewModel>> GetTeachers();
        public Task<TeacherEditViewModel> CreateTeacher();
        public Task<bool> SaveEducationalCycle(EducationalCycleEditViewModel cycleToSave);
        public Task<DepartmentEditViewModel> CreateDepartmentEditViewModel(Department department);
        public Task<EducationalCycleEditViewModel> CreateEducationalCycle(EducationalCycle educationalCycle);
        public Task<GroupEditViewModel> CreateGroup();
        public Task<TeacherEditViewModel> CreateTeacher(Teacher teacher);
        public Task<DepartmentEditViewModel> CreateDepartmentEditViewModel();
        public Task<bool> UpdateDepartment(DepartmentEditViewModel departmentToUpdate);
        public Task<Teacher> Convert2Teacher(TeacherEditViewModel teacherEditViewModel);
        public Task<bool> UpdateEducationalCycle(EducationalCycleEditViewModel cycleToUpdate);
        public Task<WorkManagementCycleEditViewModel> CreateWorkMangementCycle(WorkManagementCycle workManagementCycle);
        public Task<WorkManagementCycleEditViewModel> CreateWorkMangementCycle();
    }
}
