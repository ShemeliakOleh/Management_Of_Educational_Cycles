using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Interfaces.IEntityViewModelProviders
{
    public interface IDepartmentViewsProvider
    {
        public Task<List<SelectListItem>> GetDepartmentsByFaculty(Guid? facultyId);
        public Task<DepartmentsFilter> CreateDepartmentsFilter();
        public Task<bool> SaveDepartment(DepartmentEditViewModel departmentToSave);
        public Task<DepartmentEditViewModel> CreateDepartmentEditViewModel(Department department);
        public Task<DepartmentEditViewModel> CreateDepartmentEditViewModel();
        public Task<bool> UpdateDepartment(DepartmentEditViewModel departmentToUpdate);
    }
}
