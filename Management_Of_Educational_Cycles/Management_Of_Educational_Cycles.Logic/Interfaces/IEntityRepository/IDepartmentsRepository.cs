using Management_Of_Educational_Cycles.Domain.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Interfaces.IEntityRepository
{
    public interface IDepartmentsRepository
    {
        public Task<Department> GetById(Guid? id);
        public Task<List<Department>> GetAllDepartments();
        public Task<List<Department>> GetDepartmentsByFaculty(Guid? FacultyId);
        public Task<bool> CreateDepartment(Department department);
        public Task<bool> UpdateDepartment(Department department);
        public Task<bool> DeleteById(Guid? id);
        public Task<List<Department>> GetFilteredDepartments(Department pattern);

    }
}
