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
        public Task<bool> SaveGroup(GroupEditViewModel groupToSave);
        public Task<bool> SaveDepartment(DepartmentEditViewModel departmentToSave);
        public  Task<List<TeacherDisplayViewModel>> GetTeachers();
        public Task<TeacherEditViewModel> CreateTeacher();
        public Task<GroupEditViewModel> CreateGroup();
        public Task<TeacherEditViewModel> CreateTeacher(Teacher teacher);
        public Task<DepartmentEditViewModel> CreateDepartment();
        public Task<Teacher> Convert2Teacher(TeacherEditViewModel teacherEditViewModel);
        Task<WorkManagementCycleEditViewModel> CreateWorkMangementCycle();
    }
}
