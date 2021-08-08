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
    public class DepartmentViewsProvider : EntityProvider, IDepartmentViewsProvider
    {
        public DepartmentViewsProvider(DataManager dataManager):base(dataManager)
        {

        }
        
        public new async Task<List<SelectListItem>> GetDepartmentsByFaculty(Guid? facultyId)
        {
            return await base.GetDepartmentsByFaculty(facultyId);
        }
        public async Task<DepartmentEditViewModel> CreateDepartmentEditViewModel()
        {
            var department = new DepartmentEditViewModel()
            {
                DepartmentId = Guid.NewGuid().ToString(),
                Faculties = await GetAllFaculties(),
            };
            return department;
        }
        public async Task<bool> SaveDepartment(DepartmentEditViewModel departmentToSave)
        {
            if (departmentToSave != null)
            {
                if (Guid.TryParse(departmentToSave.DepartmentId, out Guid newGuid))
                {
                    var department = new Department()
                    {
                        Id = newGuid,
                        Name = departmentToSave.DepartmentName,
                        Groups = new List<AcademicGroup>()
                    };
                    department.FacultyId = Guid.Parse(departmentToSave.SelectedFaculty);
                    var response = await dataManager.departmentsRepository.CreateDepartment(department);
                    return true;
                }
            }
            // Return false if customeredit == null or CustomerID is not a guid
            return false;
        }
        public async Task<DepartmentEditViewModel> CreateDepartmentEditViewModel(Department department)
        {
            var departmentEditViewModel = new DepartmentEditViewModel()
            {
                DepartmentId = department.Id.ToString(),
                Faculties = await GetAllFaculties(),
                DepartmentName = department.Name,
                SelectedFaculty = department.FacultyId.ToString()
            };
            return departmentEditViewModel;
        }
        public async Task<bool> UpdateDepartment(DepartmentEditViewModel departmentToUpdate)
        {
            if (departmentToUpdate != null)
            {

                var department = new Department()
                {
                    Id = Guid.Parse(departmentToUpdate.DepartmentId),
                    Name = departmentToUpdate.DepartmentName,
                    FacultyId = Guid.Parse(departmentToUpdate.SelectedFaculty)
                };
                var response = await dataManager.departmentsRepository.UpdateDepartment(department);
                return true;
            }

            return false;
        }

        public async Task<DepartmentsFilter> CreateDepartmentsFilter()
        {
            DepartmentsFilter departmentsFilter = new DepartmentsFilter()
            {
                DepartmentName = "",
                Faculties = await GetAllFaculties(),
                Departments = await dataManager.departmentsRepository.GetDepartments()

            };
            return departmentsFilter;
        }
        
    }
}
