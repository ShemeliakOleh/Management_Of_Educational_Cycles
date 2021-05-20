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
        public IEnumerable<SelectListItem> GetDepartments();
        public Task<bool> SaveTeacher(TeacherCreateViewModel teacherToSave);
        public Task<bool> SaveDepartment(DepartmentEditViewModel departmentToSave);
        public  Task<List<TeacherDisplayViewModel>> GetTeachers();
        public Task<TeacherCreateViewModel> CreateTeacher();
        public Task<DepartmentEditViewModel> CreateDepartment();

    }
}
